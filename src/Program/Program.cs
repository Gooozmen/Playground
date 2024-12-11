using Middleware.Extensions;

var builder = WebApplication.CreateBuilder(args);
//Adding middleware services
builder.Services.ConfigureMiddlewareServices();
var app = builder.Build();

// Registered Middlewares 
//contains the setup of how the middlewares should work
app.ConfigureMiddlewares();


app.Run();
