using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Middlewares;

namespace Infrastructure.Extensions;

public static class MiddlewareRegistrationExtensions
{
    public static IServiceCollection RegisterMiddlewareServices(this IServiceCollection services)
    {
        //services.AddTransient<ResponseInterceptorMiddleware>();
        return services;
    }
}
