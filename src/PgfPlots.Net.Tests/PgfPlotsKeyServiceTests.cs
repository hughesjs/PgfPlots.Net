using PgfPlots.Net.Internal.Reflection;
using PgfPlots.Net.Public.ElementDefinitions;
using Shouldly;

namespace PgfPlots.Net.Tests;

public class PgfPlotsKeyHelperTests
{
	[Fact]
	public void CanGetPgfPlotsKeyFromProperty()
	{
		string? xLabel = PgfPlotsKeyHelper.GetPgfPlotsKey<AxisDefinition>(nameof(AxisDefinition.XLabel));

		xLabel.ShouldNotBeNullOrEmpty();
		xLabel.ShouldBe("xlabel");
	}
}
