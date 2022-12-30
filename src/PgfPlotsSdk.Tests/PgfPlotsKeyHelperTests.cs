using PgfPlotsSdk.Internal.Reflection;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlotsSdk.Tests;

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
