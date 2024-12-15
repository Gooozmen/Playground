using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterMiddlewareServices();//Adding middleware services

var app = builder.Build();

app.MapControllers();
app.ConfigureMiddlewares();// Registered Middlewares - contains the setup of how the middlewares should work


app.Run();
