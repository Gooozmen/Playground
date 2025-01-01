using Domain.Entities;
using Infrastructure.Database.EntityConfig;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
namespace Infrastructure.Database;

public class PlaygroundDbContext : DbContext, IPlaygroundDbContext
{
    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; } 

    public PlaygroundDbContext(DbContextOptions<PlaygroundDbContext> options) 
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaygroundDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

public interface IPlaygroundDbContext
{
    DbSet<Person> Persons { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}