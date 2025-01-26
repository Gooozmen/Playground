using Domain.Entities;
using Domain.Identities;
using Infrastructure.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContext : IdentityDbContext
<ApplicationUser, ApplicationRole, Guid,ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,ApplicationRoleClaim, ApplicationUserToken>, IPlaygroundDbContext
{
    private readonly DatabaseChangesInterceptor _interceptor;
    
    //Domain Models
    public virtual DbSet<User> Users { get; set; }

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
    
    //Domain Models
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}