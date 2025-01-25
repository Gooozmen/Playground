using Host;
using Host.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<MessageProcessorService>();
builder.Services.AddSingleton<MessageEndpoints>();

var app = builder.Build();

// Map custom endpoints
var endpoints = app.Services.GetRequiredService<MessageEndpoints>();
endpoints.MapEndpoints(app);

// Run the application
app.Run();
