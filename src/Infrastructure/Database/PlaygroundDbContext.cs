using Domain.Entities;
using Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class PlaygroundDbContext : DbContext, IPlaygroundDbContext
{
    private readonly DatabaseChangesInterceptor _interceptor;

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; } 

    public PlaygroundDbContext(DbContextOptions<PlaygroundDbContext> options, DatabaseChangesInterceptor interceptor) 
        : base(options)
    {
        _interceptor = interceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaygroundDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.AddInterceptors(_interceptor);
}

public interface IPlaygroundDbContext
{
    DbSet<Person> Persons { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}