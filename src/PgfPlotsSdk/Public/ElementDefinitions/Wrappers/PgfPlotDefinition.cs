using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class PgfPlotDefinition
{
    public PgfPlotDefinition(List<PlotDefinition> plotDefinitions)
    {
        PlotDefinitions = plotDefinitions;
    }

    public List<PlotDefinition> PlotDefinitions { get; }
}