using Domain.Entities;
using Infrastructure.Database.EntityConfig;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
namespace Infrastructure.Database;

public class PlaygroundDbContext : DbContext
{
    public virtual DbSet<Person> Persons { get; set; }

    public PlaygroundDbContext(DbContextOptions<PlaygroundDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaygroundDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public async Task<string> GetServerCurrentTimeAsync()
    {
        var result = await Database.ExecuteSqlRawAsync("SELECT GETDATE()");
        return result.ToString();
    }
}
