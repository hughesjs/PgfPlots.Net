using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots;

public class PlotDefinition
{
    public PlotOptions PlotOptions { get; }
    
    public List<PlotData> PlotData { get; }

    public PlotDefinition(PlotOptions plotOptions, IEnumerable<PlotData> data)
    {
        PlotOptions = plotOptions;
        PlotData = data.ToList();
    }
}