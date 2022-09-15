using Everyday.API.Authorization.Interfaces;
using Everyday.API.Authorization.Services;
using Everyday.API.Middleware;
using Everyday.Data.DataProviders;
using Everyday.Data.DataSource;
using Everyday.Data.Interfaces;
using Everyday.Services.Interfaces;
using Everyday.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Everyday.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession()
                    .AddDistributedMemoryCache()
                    .AddDbContext<EverydayContext>()
                    .AddScoped<IUserDataProvider, UserDataProvider>()
                    .AddScoped<IItemDataProvider, ItemDataProvider>()
                    .AddScoped<IConsumableDataProvider, ConsumableDataProvider>()
                    .AddScoped<IManufacturerDataProvider, ManufacturerDataProvider>()
                    .AddScoped<ICryptographyService, CryptographyService>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IItemService, ItemService>()
                    .AddScoped<IConsumableService, ConsumableService>()
                    .AddScoped<IManufacturerService, ManufacturerService>()
                    .AddScoped<ITokenService, TokenService>();

            services.AddControllers()
                    .AddNewtonsoftJson(options => 
                    {
                        options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Everyday.API", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Everyday.API v1"));
                app.UseHttpsRedirection();
            }

            app.UseMiddleware<ErrorHandler>();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.Use(async (context, next) =>
            {
                string forwardedPath = context.Request.Headers["X-Forwarded-Path"].FirstOrDefault();

                if (!string.IsNullOrEmpty(forwardedPath))
                {
                    context.Request.PathBase = forwardedPath;
                }

                await next();
            });
        }
    }
}
