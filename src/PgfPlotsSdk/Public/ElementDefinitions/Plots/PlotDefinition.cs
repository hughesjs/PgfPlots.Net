using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots;

public class PlotDefinition
{
    public PlotOptions PlotOptions { get; }
    
    public List<ILatexData> PlotData { get; }

    public PlotDefinition(PlotOptions plotOptions, IEnumerable<ILatexData> data)
    {
        PlotOptions = plotOptions;
        PlotData = data.ToList();
    }
    
    public PlotDefinition(PlotOptions plotOptions, ILatexData data)
    {
        PlotOptions = plotOptions;
        PlotData = new() { data };
    }
}