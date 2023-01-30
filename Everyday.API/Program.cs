using Everyday.API.Middleware;
using Everyday.Infrastructure;
using Everyday.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Everyday.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateApp(args).Run();
        }

        public static WebApplication CreateApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ErrorHandlingMeddleware>();

            return app;
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSession()
                    .AddDistributedMemoryCache()
                    .AddPersistenceServices()
                    .AddInfrastructureServices(configuration);

            services.AddTransient<ErrorHandlingMeddleware>();

            services.AddSwaggerGen();
            services.AddRouting(x => x.LowercaseUrls = true);

            services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false)
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            services.AddMediatR(typeof(Program));
        }
    }
}
