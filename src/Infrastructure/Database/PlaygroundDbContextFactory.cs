using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shared.Options;

namespace Infrastructure.Database;

public class PlaygroundDbContextFactory : IDesignTimeDbContextFactory<PlaygroundDbContext>
{

    public PlaygroundDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PlaygroundDbContext>();
        optionsBuilder.UseSqlServer("Server=tcp:playgrounddatabase.cx86qgkw280r.us-east-1.rds.amazonaws.com,1433;Database=PlaygroundDb;User Id=admin;Password=Guzm44n27141903;TrustServerCertificate=True;");

        return new PlaygroundDbContext(optionsBuilder.Options);
    }
}


