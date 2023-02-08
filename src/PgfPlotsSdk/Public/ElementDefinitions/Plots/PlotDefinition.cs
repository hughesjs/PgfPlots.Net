using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots;

public class PlotDefinition<TOptions>: PlotDefinition where TOptions: OptionsDefinition
{
    public override TOptions PlotOptions { get; }

    public PlotDefinition(TOptions plotOptions, params ILatexData[] data) : base(plotOptions, data)
    {
        PlotOptions = plotOptions;
    }

}

public class PlotDefinition
{
    public virtual OptionsDefinition PlotOptions { get; }
    
    public ILatexData[] PlotData { get; }

    public PlotDefinition(OptionsDefinition plotOptions, params ILatexData[] data)
    {
        PlotOptions = plotOptions;
        PlotData = data;
    }
}