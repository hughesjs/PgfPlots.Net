using PgfPlots.Net.ElementDefinitions;
using PgfPlots.Net.Services;
using Shouldly;

namespace PgfPlots.Net.Tests;

public class PgfPlotsKeyServiceTests
{
	private readonly PgfPlotsKeyService _service;

	public PgfPlotsKeyServiceTests()
	{
		_service = new();
	}


	[Fact]
	public void CanGetPgfPlotsKeyFromProperty()
	{
		string? xLabel = _service.GetPgfPlotsKey<AxisDefinition>(nameof(AxisDefinition.XLabel));

		xLabel.ShouldNotBeNullOrEmpty();
		xLabel.ShouldBe("xlabel");
	}
}
