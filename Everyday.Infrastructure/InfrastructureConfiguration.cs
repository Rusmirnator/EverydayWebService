using Everyday.Application.Common.Interfaces.Services;
using Everyday.Infrastructure.Common.Options;
using Everyday.Infrastructure.Common.Services;
using Everyday.Infrastructure.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Everyday.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICryptographyService, CryptographyService>(provider =>
            {
                CryptographyService service = new(provider.GetRequiredService<ILogger<CryptographyService>>());

                service.Options = new CryptographyOptions(configuration["Encryption:AESKey"], AesType.AES256);

                return service;
            })
            .AddScoped<ITokenService, TokenService>(provider =>
            {
                TokenService service = new();

                service.Options = new TokenOptions(configuration.GetValue<int>("JWT:Lifetime"),
                                                   configuration["JWT:Key"],
                                                   configuration["JWT:Issuer"],
                                                   configuration["JWT:Audience"]);

                return service;
            })
            .AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
