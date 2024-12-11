using Microsoft.Extensions.DependencyInjection;
using Middleware.Entities;

namespace Middleware.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection ConfigureMiddlewareServices(this IServiceCollection services)
    {
        services.AddTransient<BasicMiddleware>();
        services.AddTransient<DistributionMiddleware>();
        services.AddTransient<AccessMiddleware>();
        return services;
    }
}
