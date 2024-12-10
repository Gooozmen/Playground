using Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Registered Middlewares

app.UseMiddlewares();


app.Run();
