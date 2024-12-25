using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middlewares;

internal class RequestIdMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var requestId = Guid.NewGuid().ToString();

        // Store the request ID in HttpContext
        context.Items["RequestId"] = requestId;

        // Add it to the response headers
        context.Response.Headers.Add("X-Request-ID", requestId);

        await next(context);
    }
}
