using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(); // Registers controllers and API endpoints
builder.Services.RegisterMiddlewareServices();//Adding middleware services
// Optional: Add Swagger (if needed for testing)
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization(); // Ensure proper authorization middleware is in place
// Map controllers to endpoints
app.MapControllers(); // This is critical to route requests to controllers
app.ConfigureMiddlewares();// Registered Middlewares - contains the setup of how the middlewares should work
app.Run();