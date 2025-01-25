using Host.Entities;
using Host.Services;

namespace Host;

public class MessageEndpoints
{
    private readonly MessageProcessorService _processor;

    public MessageEndpoints(MessageProcessorService processor)
    {
        _processor = processor;
    }

    public void MapEndpoints(WebApplication app)
    {
        // Custom endpoint to receive messages
        app.MapPost("/api/messages", async (HttpContext context) =>
        {
            var message = await context.Request.ReadFromJsonAsync<Message>();
            if (message is null)
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("Invalid message payload.");
                return;
            }

            var result = await _processor.ProcessMessageAsync(message);
            context.Response.StatusCode = 200; // OK
            await context.Response.WriteAsync($"Message processed: {result}");
        });

        // Optional: Add more endpoints if needed
        app.MapGet("/", () => "Message Receiver Service is running!");
    }
}
