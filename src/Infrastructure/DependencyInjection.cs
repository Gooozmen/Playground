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
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        //app.UseMiddleware<ResponseInterceptorMiddleware>();
        //app.UseMiddleware<RequestIdMiddleware>();
        return app;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlaygroundDbContext>(options =>
        {
            options.UseSqlServer
            (
                configuration.GetConnectionString("PlaygroundDb"),
                builder =>
                {
                    builder.MigrationsAssembly(typeof(PlaygroundDbContext).Assembly.FullName);
                    builder.CommandTimeout(15);
                }
            );
            options.EnableDetailedErrors(detailedErrorsEnabled: true);
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IDbContextFactory<PlaygroundDbContext>, PlaygroundDbContextFactory<PlaygroundDbContext>>();
        services.AddTransient<IPlaygroundDbContext>(provider => provider.GetRequiredService<IDbContextFactory<PlaygroundDbContext>>().CreateDbContext());
        services.AddScoped<PlaygroundDbContextInitializer>();

        // Register your services
        services.AddSingleton<IWeatherstackClient, WeatherstackClient>();

        // Seeders
        services.AddScoped<IContextInitializer, PlaygroundDbContextInitializer>();
        services.AddScoped<ISeederService, PersonSeederService>();
        services.AddScoped<ISeederService, UserRoleSeederService>();
        services.AddScoped<ISeederService, UserSeederService>();

        return services;
    }

}

