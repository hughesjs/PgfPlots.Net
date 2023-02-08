using Microsoft.Extensions.DependencyInjection;
using PgfPlotsSdk.Public.DependencyInjection;
using PgfPlotsSdk.Public.Interfaces.Services;
using Shouldly;

namespace PgfPlotsSdk.Tests.DependencyInjection;

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