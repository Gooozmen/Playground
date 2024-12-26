using Microsoft.AspNetCore.Builder;
using Infrastructure.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.HttpClient;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IApplicationBuilder UseInfrastructureMiddlewares(this IApplicationBuilder app)
    {
        //app.UseMiddleware<ResponseInterceptorMiddleware>();
        app.UseMiddleware<RequestIdMiddleware>();
        return app;
    }

    public static IServiceCollection AddMiddlewareServices(this IServiceCollection services)
    {
        services.AddSingleton<IWeatherstackClient, WeatherstackClient>();
        services.AddScoped<RequestIdMiddleware>();
        return services;
    }
}

