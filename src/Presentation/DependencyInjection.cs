using Presentation.Environments;
using Shared.Options;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        // Add configuration options
        services.Configure<WeatherstackApi>(configuration.GetSection("Weatherstack"));
        services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

        return services;
    }

    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        //Singletons
        services.AddSingleton<IEnvironmentValidator, EnvironmentValidator>();


        return services;
    }
    public static IConfigurationBuilder AddDefaultConfiguration<T>(this IConfigurationBuilder configurationBuilder) where T : class
    {
        // Add appsettings.json
        configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


        // Add user secrets
        configurationBuilder.AddUserSecrets<T>();

        return configurationBuilder;
    }
}




