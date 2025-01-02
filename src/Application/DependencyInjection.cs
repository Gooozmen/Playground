using Microsoft.Extensions.DependencyInjection;
using Application.Factories;
using Application.Services;
using RandomNameGeneratorLibrary;
using Shared.Helpers;
using Application.Mappings;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Factories
        services.AddTransient<IResponseFactory, ResponseFactory>();

        //Services
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IWeatherService, WeatherService>();
        services.AddSingleton<IPersonNameGenerator, PersonNameGenerator>(); //External

        //Helpers
        services.AddSingleton<INumericHelper, NumericHelper>();
        services.AddSingleton<IPersonGeneratorHelper, PersonGeneratorHelper>();
        services.AddSingleton<IJsonHelper, JsonHelper>();

        //AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
