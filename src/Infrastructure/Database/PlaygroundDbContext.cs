using Domain.Entities;
using Infrastructure.Database.EntityConfig;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
namespace Infrastructure.Database;

public class PlaygroundDbContext : DbContext
{
    public PlaygroundDbContext(DbContextOptions<PlaygroundDbContext> options) : base(options)
    {

    }
    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaygroundDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
