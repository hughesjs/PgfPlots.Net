using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class PgfPlotDefinition
{
    public PgfPlotDefinition(AxisOptions axisOptions)
    {
        AxisOptions = axisOptions;
        PlotDefinitions = new();
    }

    public PgfPlotDefinition(AxisOptions axisOptions, List<PlotDefinition> plotDefinitions)
    {
        AxisOptions = axisOptions;
        PlotDefinitions = plotDefinitions;
    }

    public AxisOptions AxisOptions { get; }

    public AxisType AxisType { get; } = AxisType.Standard;
    public List<PlotDefinition> PlotDefinitions { get; }
}