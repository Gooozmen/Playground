using Microsoft.AspNetCore.Builder;

namespace Playground.Controllers;

public static class ApplicationRegistrationExtensions 
{
	public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
	{
		services.AddControllers();
		return services;
	}
}
