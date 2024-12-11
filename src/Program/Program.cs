using Middleware.Extensions;
using Playground.Controllers;
using Playground.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationServices();
builder.Services.RegisterMiddlewareServices();//Adding middleware services
var app = builder.Build();

app.ConfigureApplicationServices(); // Register generic middlewares
app.ConfigureMiddlewares();// Registered Middlewares - contains the setup of how the middlewares should work


app.Run();
