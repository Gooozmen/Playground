using Host.Entities;

namespace Host.Services;

public class MessageProcessorService
{
    public Task<string> ProcessMessageAsync(Message message)
    {
        // Simulate message processing
        Console.WriteLine($"Received message: {message.Content}");
        return Task.FromResult($"Processed message with ID: {message.Id}");
    }
}
