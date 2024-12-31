using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.ApplicationHttpClient;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Options;
using Infrastructure.Database.Seeds;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IApplicationBuilder UseInfrastructureMiddlewares(this IApplicationBuilder app)
    {
        //app.UseMiddleware<ResponseInterceptorMiddleware>();
        //app.UseMiddleware<RequestIdMiddleware>();
        return app;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register your services
        services.AddSingleton<IWeatherstackClient, WeatherstackClient>();

        // Seeders
        services.AddTransient<ISeederService,PersonSeederService>();
        services.AddSingleton<IDatabaseSeeder,DatabaseSeeder>();

        // Add DbContext with configuration for the connection string
        services.AddDbContext<PlaygroundDbContext>(options =>
        {

            options.UseSqlServer(configuration.GetConnectionString("PlaygroundDB"));
        });

        return services;
    }

}

