using PgfPlots.Net.Internal.Reflection;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlots.Net.Tests;

public class PgfPlotsKeyHelperTests
{
	[Fact]
	public void CanGetPgfPlotsKeyFromProperty()
	{
		string? xLabel = PgfPlotsAttributeHelper.GetPgfPlotsKey<AxisOptions>(nameof(AxisOptions.XLabel));

		xLabel.ShouldNotBeNullOrEmpty();
		xLabel.ShouldBe("xlabel");
	}
	
	[Fact]
	public void CanCheckIfPropertyIsValueOnly()
	{
		bool? isValueOnly = PgfPlotsAttributeHelper.IsValueOnlyField<PlotOptions>(nameof(PlotOptions.LineStyle));
		bool? isValueOnly2 = PgfPlotsAttributeHelper.IsValueOnlyField<PlotOptions>(nameof(PlotOptions.LineWidth));
		isValueOnly.ShouldBe(true);
		isValueOnly2.ShouldBe(false);
	}
}
