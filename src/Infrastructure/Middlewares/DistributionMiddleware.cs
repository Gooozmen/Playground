using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middlewares;

public class DistributionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Im the distribution middleware\n");
        await context.Response.WriteAsync("Verifying\n");
        await next(context);
        await context.Response.WriteAsync("Distributing - Ending\n");
    }

    private bool VerifyUser(HttpContext context)
    {
        var result = context.Request.Query.ContainsKey("username");

        return result;
    }
}