using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Dependency
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		return services;
	}
}