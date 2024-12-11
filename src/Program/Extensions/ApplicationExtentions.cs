namespace Playground.Extensions;

public static class ApplicationExtentions
{
    public static IApplicationBuilder ConfigureApplicationServices(this IApplicationBuilder app)
    {
        app.UseRouting();
        return app;
    }

}

