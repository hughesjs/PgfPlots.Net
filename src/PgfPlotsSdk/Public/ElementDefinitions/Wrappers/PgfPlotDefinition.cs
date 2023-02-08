using PgfPlotsSdk.Public.ElementDefinitions.Plots;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class PgfPlotDefinition
{
    public PgfPlotDefinition(params PlotDefinition[] plotDefinitions)
    {
        PlotDefinitions = plotDefinitions.ToList();
    }

    public List<PlotDefinition> PlotDefinitions { get; }
}