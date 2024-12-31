using Presentation.Environments;
using Shared.Options;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        // Add configuration options
        services.Configure<WeatherstackApi>(configuration.GetSection("Weatherstack"));

        return services;
    }

    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        //Singletons
        services.AddSingleton<IEnvironmentValidator, EnvironmentValidator>();


        return services;
    }
}




