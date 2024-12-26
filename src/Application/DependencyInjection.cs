using Microsoft.Extensions.DependencyInjection;
using Application.Factories;
using Application.Services;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Transients
        services.AddTransient<IResponseFactory, ResponseFactory>();
        services.AddTransient<IWeatherService, WeatherService>();

        return services;
    }
}
