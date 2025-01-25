using Domain.Entities;
using Domain.Identities;
using Infrastructure.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>, IPlaygroundDbContext
{
    private readonly DatabaseChangesInterceptor _interceptor;

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DatabaseChangesInterceptor interceptor) 
        : base(options)
    {
        _interceptor = interceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.AddInterceptors(_interceptor);
}

public interface IPlaygroundDbContext
{
    //Identity 
    DbSet<ApplicationUser> ApplicationUsers { get; set; }
    DbSet<ApplicationRole> ApplicationRoles { get; set; }

    //Domain Models
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}