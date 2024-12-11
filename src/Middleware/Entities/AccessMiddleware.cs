using Microsoft.AspNetCore.Http;

namespace Middleware.Entities;

public class AccessMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Im the Access middleware\n");
        await context.Response.WriteAsync("Providing Access\n");
        // As this is the last middleware it doesnt need to continue
        //await _next(context);
    }
}
