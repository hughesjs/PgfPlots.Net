using PgfPlotsSdk.Public.Interfaces.Data;
using PgfPlotsSdk.Public.Models.Options;

namespace PgfPlotsSdk.Internal.ElementDefinitions;

internal class PlotDefinition<TOptions>: PlotDefinition where TOptions: OptionsDefinition
{
    public override TOptions PlotOptions { get; }

    public PlotDefinition(TOptions plotOptions, params ILatexData[] data) : base(plotOptions, data)
    {
        PlotOptions = plotOptions;
    }

}

internal class PlotDefinition
{
    public virtual OptionsDefinition PlotOptions { get; }
    
    public ILatexData[] PlotData { get; }

    public PlotDefinition(OptionsDefinition plotOptions, params ILatexData[] data)
    {
        PlotOptions = plotOptions;
        PlotData = data;
    }
}