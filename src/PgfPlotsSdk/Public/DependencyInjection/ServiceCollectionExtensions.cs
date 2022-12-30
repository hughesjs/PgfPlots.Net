using Microsoft.Extensions.DependencyInjection;
using PgfPlotsSdk.Internal.Services;
using PgfPlotsSdk.Public.Interfaces.Services;

namespace PgfPlotsSdk.Public.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddPgfPlotsServices(this IServiceCollection services)
	{
		services.AddTransient<IPgfPlotSourceGenerator, PgfPlotSourceGenerator>();
		return services;
	}
}