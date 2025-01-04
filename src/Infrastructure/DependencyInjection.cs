using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.ApplicationHttpClient;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Database.Seeds;
using Infrastructure.Repositories;
using Infrastructure.Interceptors;

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

        // Db Context
        services.AddScoped<IDbContextFactory<PlaygroundDbContext>, PlaygroundDbContextFactory<PlaygroundDbContext>>();
        services.AddTransient<IPlaygroundDbContext>(provider => provider.GetRequiredService<IDbContextFactory<PlaygroundDbContext>>().CreateDbContext());
        services.AddScoped<PlaygroundDbContextInitializer>();
        services.AddScoped<DatabaseChangesInterceptor>();

        // Repositories
        services.AddTransient<IUserRepository, UserRepository>();

        // Clients
        services.AddSingleton<IWeatherstackClient, WeatherstackClient>();

        // Seeders
        services.AddScoped<ISeederService, PersonSeederService>();
        services.AddScoped<ISeederService, UserRoleSeederService>();
        services.AddScoped<ISeederService, UserSeederService>();

        return services;
    }

}

