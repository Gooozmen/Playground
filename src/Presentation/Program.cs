#region Usings
using Infrastructure;
using Application;
using Presentation.Environments;
using Presentation;
using Infrastructure.Database;
using Presentation.Extensions;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Configuration Options
builder.Services.AddConfigurationOptions(builder.Configuration);

// Register HttpClientFactory
builder.Services.AddHttpClient();

// Registers controllers and API endpoints
builder.Services.AddControllers().AddCustomJsonOptions();

// Services Registration by Application Layer
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCoreServices();

var app = builder.Build();

var environmentValidation = app.Services.GetRequiredService<IEnvironmentValidator>().IsDevelopment();

// Configure middleware pipeline
app.UseInfrastructure(); // Custom middleware configuration (e.g., authentication, logging)
app.UseStaticFiles(); // Serve static files (should come early to serve files directly)
app.UseRouting(); // Enable routing for middleware and endpoints
app.MapControllers(); // Map controllers to endpoints

if (environmentValidation)
{
    app.UseDeveloperExceptionPage();
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<PlaygroundDbContextInitializer>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAllAsync();
    }
}
// Start the application
app.Run();
