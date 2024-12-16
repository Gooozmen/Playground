using Microsoft.AspNetCore.Builder;
using Infrastructure.Middlewares;

namespace Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder ConfigureMiddlewares(this IApplicationBuilder app)
    {
        //app.UseMiddleware<ResponseInterceptorMiddleware>();

        return app;
    }
}

