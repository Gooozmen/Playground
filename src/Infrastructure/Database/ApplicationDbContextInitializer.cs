﻿using Infrastructure.Database.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContextInitializer : IContextInitializer
{
    private readonly IEnumerable<ISeederService> _seeders;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(IEnumerable<ISeederService> seeders,ApplicationDbContext context)
    {
        _seeders = seeders;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            var executedrop = false;
            
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" && executedrop)
            {
                // Drop tables in the correct order based on foreign key dependencies
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetUserRoles]"); // Dependent on AspNetUsers and AspNetRoles
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetRoleClaims]"); // Dependent on AspNetRoles
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetUserClaims]"); // Dependent on AspNetUsers
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetUserLogins]"); // Dependent on AspNetUsers
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetUserTokens]"); // Dependent on AspNetUsers
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetRoles]"); // Parent of AspNetRoleClaims and AspNetUserRoles
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [AspNetUsers]"); // Parent of AspNetUserRoles, AspNetUserClaims, AspNetUserLogins, and AspNetUserTokens
                await _context.Database.ExecuteSqlRawAsync("DROP TABLE IF EXISTS [User]");
                
                if (_context.Database.IsSqlServer())
                    await _context.Database.MigrateAsync();
            }
            
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task SeedAllAsync()
    {
        var userSeeder = _seeders.FirstOrDefault(seeder => seeder.GetType() == typeof(UserSeederService));
        if (userSeeder != null) await userSeeder.SeedAsync();

        await _context.SaveChangesAsync();
    }
}

public interface IContextInitializer
{
    Task InitialiseAsync();
    Task SeedAllAsync();
}
