using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class PlaygroundDbContextFactory : IDesignTimeDbContextFactory<PlaygroundDbContext>
{
    public PlaygroundDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PlaygroundDbContext>();
        optionsBuilder.UseSqlServer("YourConnectionStringHere");

        return new PlaygroundDbContext(optionsBuilder.Options);
    }
}
