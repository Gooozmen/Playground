using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;
public class PlaygroundDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
{
    private readonly IServiceProvider _provider;

    public PlaygroundDbContextFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public TContext CreateDbContext()
    {
        if (_provider == null)
            throw new InvalidOperationException("You must configure an instance of IServiceProvider");

        return ActivatorUtilities.CreateInstance<TContext>(_provider);
    }
}


