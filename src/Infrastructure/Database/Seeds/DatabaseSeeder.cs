using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Database.Seeds;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IEnumerable<ISeederService> _seeders;

    public DatabaseSeeder(IEnumerable<ISeederService> seeders)
    {
        _seeders = seeders;
    }

    public async Task SeedAsync(DbContext context)
    {
        foreach (var seeder in _seeders)
        {
            var seederType = seeder.GetType();
            var tableName = seederType.GetField("TableName")?.GetValue(null)?.ToString();

            if (string.IsNullOrEmpty(tableName))
                continue;

            Console.WriteLine($"Checking table: {tableName}");

            if (await TableExistsAsync(context, tableName))
            {
                await seeder.SeedAsync();
            }
            else
            {
                Console.WriteLine($"Table '{tableName}' does not exist. Skipping seeding.");
            }
        }
    }

    public async Task<bool> TableExistsAsync(DbContext context, string tableName)
    {
        var connection = context.Database.GetDbConnection();
        await using var command = connection.CreateCommand();
        command.CommandText = $@"
            SELECT CASE 
                WHEN EXISTS (
                    SELECT * 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_NAME = '{tableName}'
                ) THEN 1 
                ELSE 0 
            END;";
        await connection.OpenAsync();
        var result = await command.ExecuteScalarAsync();
        await connection.CloseAsync();

        return Convert.ToInt32(result) == 1;
    }

}
public interface IDatabaseSeeder
{
    Task SeedAsync(DbContext context);
    Task<bool> TableExistsAsync(DbContext context, string tableName);
}
