using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots.Data;

internal class RawDataCollectionNode: SyntaxNode
{
    public RawDataCollectionNode(IEnumerable<PlotData> data)
    {
        Children.AddRange(data.Select(d => new RawDataNode(d)));
    }
    
    public RawDataCollectionNode(PlotData data) // For instances where you've built a collection container already
    {
        Children.Add(new RawDataNode(data));
    }

    protected override string BeforeChildren => "plot coordinates {";
    protected override string BetweenChildren => " ";
    protected override string AfterChildren => "}";

}