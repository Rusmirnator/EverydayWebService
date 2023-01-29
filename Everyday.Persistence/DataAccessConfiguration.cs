using Everyday.Application.Common.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Everyday.Persistence
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDataAccess();

            return services;
        }

        #region Private API
        private static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<EverydayDbContext>(options =>
            {
                if (options.IsConfigured)
                {
                    return;
                }

                options
                    .UseNpgsql(BuildConnectionString(Environment.GetEnvironmentVariable("PG_CONNSTRING_DEV")), options =>
                    {
                        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    });
            });

            services.AddScoped<IEverydayDbContext, EverydayDbContext>();

            return services;
        }

        private static string BuildConnectionString(string? databaseUrl)
        {
            if (Uri.TryCreate(databaseUrl, UriKind.Absolute, out Uri? uri))
            {
                return $"Host={uri.Host};Username={uri.UserInfo.Split(':')[0]};" +
                    $"Password={uri.UserInfo.Split(':')[1]};Database={uri.LocalPath[1..]};" +
                    $"Port={uri.Port};sslmode=Require;Trust Server Certificate=true";
            }
            return databaseUrl ?? string.Empty;
        }
        #endregion
    }
}
