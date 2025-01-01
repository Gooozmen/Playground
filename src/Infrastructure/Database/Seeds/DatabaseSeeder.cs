namespace Infrastructure.Database.Seeds;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IEnumerable<ISeederService> _seeders;
    private readonly PlaygroundDbContext _context;

    public DatabaseSeeder(IEnumerable<ISeederService> seeders,PlaygroundDbContext context)
    {
        _seeders = seeders;
        _context = context;
    }

    public async Task SeedAllAsync()
    {
        var personSeeder = _seeders.FirstOrDefault(seeder => seeder.GetType() == typeof(PersonSeederService));
        if (personSeeder != null) await personSeeder.SeedAsync();
        var userRoleSeeder = _seeders.FirstOrDefault(seeder => seeder.GetType() == typeof(UserRoleSeederService));
        if (userRoleSeeder != null) await userRoleSeeder.SeedAsync();
        var userSeeder = _seeders.FirstOrDefault(seeder => seeder.GetType() == typeof(UserSeederService));
        if (userSeeder != null) await userSeeder.SeedAsync();

        await _context.SaveChangesAsync();
    }
}

public interface IDatabaseSeeder
{
    Task SeedAllAsync();
}
