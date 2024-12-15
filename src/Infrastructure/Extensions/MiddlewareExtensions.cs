﻿using Microsoft.AspNetCore.Builder;
using Infrastructure.Services;

namespace Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder ConfigureMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<BasicMiddleware>();
        app.UseMiddleware<DistributionMiddleware>();
        app.UseMiddleware<AccessMiddleware>();

        return app;
    }
}
