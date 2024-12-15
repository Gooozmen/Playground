using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class BasicMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Im a basic middleware\n");
        await next(context);
        await context.Response.WriteAsync("Basic middleware Ends\n");
    }
}
