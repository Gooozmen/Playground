﻿using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;

namespace Infrastructure.Extensions;

public static class MiddlewareRegistrationExtensions
{
    public static IServiceCollection RegisterMiddlewareServices(this IServiceCollection services)
    {
        services.AddTransient<BasicMiddleware>();
        services.AddTransient<DistributionMiddleware>();
        services.AddTransient<AccessMiddleware>();
        return services;
    }
}
