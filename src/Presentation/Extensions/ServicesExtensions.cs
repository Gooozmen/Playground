using Presentation.Factories;
using Presentation.Responses;

namespace Presentation.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IResponseFactory<>), typeof(ResponseFactory<>));

        return services;
    }
}


