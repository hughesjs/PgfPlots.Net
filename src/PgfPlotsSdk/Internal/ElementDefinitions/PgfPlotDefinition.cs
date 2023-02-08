namespace PgfPlotsSdk.Internal.ElementDefinitions;

internal class PgfPlotDefinition
{
    public PgfPlotDefinition(params PlotDefinition[] plotDefinitions)
    {
        PlotDefinitions = plotDefinitions.ToList();
    }

    public List<PlotDefinition> PlotDefinitions { get; }
}