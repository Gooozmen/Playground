using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.ApplicationHttpClient;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Database.Seeds;
using Infrastructure.Repositories;
using Infrastructure.Interceptors;
using Infrastructure.Mappings;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Infrastructure.Managers;

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
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer
            (
                configuration.GetConnectionString("PlaygroundDb"),
                builder =>
                {
                    builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    builder.CommandTimeout(15);
                }
            );
            options.EnableDetailedErrors(detailedErrorsEnabled: true);
            options.EnableSensitiveDataLogging();
        });

        // Db Context
        services.AddIdentity<ApplicationUser, ApplicationRole>() // Use ApplicationRole instead of IdentityRole
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>() // Match your custom user and role types
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>() // Match your custom role type
                .AddDefaultTokenProviders();

        services.AddScoped<IDbContextFactory<ApplicationDbContext>, ApplicationDbContextFactory<ApplicationDbContext>>();
        services.AddTransient<IPlaygroundDbContext>(provider => provider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());
        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddScoped<DatabaseChangesInterceptor>();

        // Repositories
        services.AddTransient<IUserRepository, UserRepository>();

        // Clients
        services.AddSingleton<IWeatherstackClient, WeatherstackClient>();

        //facade
        services.AddScoped<IApplicationUserManager, ApplicationUserManager>();

        // Seeders
        services.AddScoped<ISeederService, UserSeederService>();

        //AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}

