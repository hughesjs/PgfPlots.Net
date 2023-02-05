using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots;

public class PlotDefinition
{
    public OptionsDefinition PlotOptions { get; }
    
    public List<ILatexData> PlotData { get; }

    public PlotDefinition(OptionsDefinition plotOptions, IEnumerable<ILatexData> data)
    {
        PlotOptions = plotOptions;
        PlotData = data.ToList();
    }
    
    public PlotDefinition(OptionsDefinition plotOptions, ILatexData data)
    {
        PlotOptions = plotOptions;
        PlotData = new() { data };
    }
}