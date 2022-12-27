using Microsoft.Extensions.DependencyInjection;
using PgfPlots.Net.Internal.Services;
using PgfPlots.Net.Public.Interfaces.Services;

namespace PgfPlots.Net.Public.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddPgfPlotsServices(this IServiceCollection services)
	{
		services.AddTransient<IPgfPlotSourceGenerator, PgfPlotSourceGenerator>();
		return services;
	}
}