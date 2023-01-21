using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class PgfPlotDefinition
{
    public PgfPlotDefinition(AxisOptions axisOptions, AxisType axisType)
    {
        AxisType = axisType;
        AxisOptions = axisOptions;
        PlotDefinitions = new();
    }

    public PgfPlotDefinition(AxisOptions axisOptions, AxisType axisType, List<PlotDefinition> plotDefinitions)
    {
        AxisOptions = axisOptions;
        AxisType = axisType;
        PlotDefinitions = plotDefinitions;
    }

    public AxisOptions AxisOptions { get; }

    public AxisType AxisType { get; }
    public List<PlotDefinition> PlotDefinitions { get; }
}