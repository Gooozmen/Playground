using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text;
using Common.HttpResponses;

namespace Infrastructure.Middlewares;


public class ResponseInterceptorMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Path.Value.Contains("api", StringComparison.OrdinalIgnoreCase))
        {
            // If not an API request, proceed without modification
            await next(context);
            return;
        }

        // Capture the original response body
        var originalResponseBody = context.Response.Body;

        try
        {
            // Use a memory stream to intercept the response
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await next(context); // Execute the next middleware

            // Read the response
            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Prepare the wrapped response
            var modifiedResponse = new ResponseBase<string>(
                isSuccess: context.Response.StatusCode >= 200 && context.Response.StatusCode < 300,
                statusCode: context.Response.StatusCode,
                message: "Request processed successfully",
                data: responseBody
            );

            // Serialize the modified response
            var jsonResponse = JsonSerializer.Serialize(modifiedResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            // Set the response content type and body
            context.Response.ContentType = "application/json";
            context.Response.Body = originalResponseBody;
            await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
        }
        finally
        {
            context.Response.Body = originalResponseBody; // Restore original response body
        }
    }
}

