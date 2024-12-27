using Microsoft.Extensions.DependencyInjection;
using Application.Factories;
using Application.Services;
using RandomNameGeneratorLibrary;
using Application.Helpers;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Factories
        services.AddTransient<IResponseFactory, ResponseFactory>();

        //services
        services.AddTransient<IWeatherService, WeatherService>();

        services.AddSingleton<IPersonNameGenerator, PersonNameGenerator>();

        //Helpers
        services.AddSingleton<INumericHelper, NumericHelper>();
        services.AddSingleton<IPersonGeneratorHelper, PersonGeneratorHelper>();

        return services;
    }
}
