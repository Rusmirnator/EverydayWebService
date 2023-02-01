﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Everyday.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddRequestHandlers();

            return services;
        }

        private static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationConfiguration).Assembly);

            return services;
        }
    }
}
