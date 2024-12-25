using Infrastructure.Extensions;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add all required services to the container.
builder.Services.AddControllers(); // Registers controllers and API endpoints
builder.Services.RegisterMiddlewareServices(); // Adding middleware services
builder.Services.RegisterServices(); // Register other services

var app = builder.Build();

// Configure middleware pipeline
app.UseStaticFiles(); // Serve static files (should come early to serve files directly)
app.UseRouting(); // Enable routing for middleware and endpoints
app.ConfigureMiddlewares(); // Custom middleware configuration (e.g., authentication, logging)

// Map endpoints
app.MapControllers(); // Map controllers to endpoints

// Start the application
app.Run();
