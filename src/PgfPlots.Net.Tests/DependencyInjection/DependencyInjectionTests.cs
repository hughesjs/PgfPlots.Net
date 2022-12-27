using Microsoft.Extensions.DependencyInjection;
using PgfPlots.Net.Public.DependencyInjection;
using PgfPlots.Net.Public.Interfaces.Services;
using Shouldly;

namespace PgfPlots.Net.Tests.DependencyInjection;

public class ServiceCollectionExtensionTests
{
	[Fact]
	public void CanResolveGeneratorAfterSettingUpServices()
	{
		ServiceCollection services = new();
		services.AddPgfPlotsServices();
		IServiceProvider provider = services.BuildServiceProvider();
		
		IPgfPlotSourceGenerator service = provider.GetRequiredService<IPgfPlotSourceGenerator>();

		service.ShouldNotBeNull();
	}
}