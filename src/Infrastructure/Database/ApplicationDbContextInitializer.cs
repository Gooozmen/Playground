using Infrastructure.Database.Seeds;
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
            if (_context.Database.IsSqlServer())
                await _context.Database.MigrateAsync();
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
