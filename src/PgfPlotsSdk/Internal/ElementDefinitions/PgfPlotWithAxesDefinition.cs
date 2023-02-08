using PgfPlotsSdk.Public.Models.Enums;
using PgfPlotsSdk.Public.Models.Options;

namespace PgfPlotsSdk.Internal.ElementDefinitions;

internal class PgfPlotWithAxesDefinition: PgfPlotDefinition
{
	public PgfPlotWithAxesDefinition(AxisOptions axisOptions, AxisType axisType)
	{
		AxisType = axisType;
		AxisOptions = axisOptions;
	}

	public PgfPlotWithAxesDefinition(AxisOptions axisOptions, AxisType axisType, params PlotDefinition[] plotDefinitions): base(plotDefinitions)
	{
		AxisOptions = axisOptions;
		AxisType = axisType;
	}
	
	public AxisOptions AxisOptions { get; }

	public AxisType AxisType { get; }
}