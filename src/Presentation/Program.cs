using Infrastructure;
using Application;
using Presentation.Environments;
using Presentation;
using Infrastructure.Database.Seeds;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration Options
builder.Services.AddConfigurationOptions(builder.Configuration);

// Register HttpClientFactory
builder.Services.AddHttpClient();

// Add all required services to the container.
builder.Services.AddControllers(); // Registers controllers and API endpoints
builder.Services.AddInfrastructureServices(builder.Configuration); // Infrastructure Services Registration
builder.Services.AddApplicationServices(); // Application Services Registration
builder.Services.AddCoreServices(); // Presentation Services Registration

var app = builder.Build();

var environmentValidation = app.Services.GetRequiredService<IEnvironmentValidator>().IsDevelopment();

if (environmentValidation) 
    app.UseDeveloperExceptionPage();

// Configure middleware pipeline
app.UseInfrastructureMiddlewares(); // Custom middleware configuration (e.g., authentication, logging)
app.UseStaticFiles(); // Serve static files (should come early to serve files directly)
app.UseRouting(); // Enable routing for middleware and endpoints
app.MapControllers(); // Map controllers to endpoints

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PlaygroundDbContext>();
    await dbContext.Database.MigrateAsync();
    var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
    await seeder.SeedAsync(dbContext);
}


// Start the application
app.Run();
