using System.Collections;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;

internal class RawDataCollectionNode: SyntaxNode
{
    public RawDataCollectionNode(IEnumerable data)
    {
        Children.AddRange(data.Cast<object>().Select(d => new RawDataNode(d)));
    }

    protected override string BeforeChildren => "plot coordinates {";
    protected override string BetweenChildren => " ";
    protected override string AfterChildren => "}";

}