using Microsoft.AspNetCore.Http;

namespace Middleware.Entities;

public class DistributionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Im the distribution middleware\n");
        await next(context);
        await context.Response.WriteAsync("Distributing - Ending\n");
    }
}