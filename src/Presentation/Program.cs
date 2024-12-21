using Infrastructure.Extensions;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add all required services to the container.
builder.Services.AddControllers(); // Registers controllers and API endpoints
builder.Services.RegisterMiddlewareServices();//Adding middleware services
builder.Services.RegisterServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.ConfigureMiddlewares();// Registered Middlewares - contains the setup of how the middlewares should work
app.MapControllers(); // Map controllers to endpoints, This is critical to route requests to controllers
app.Run();