using PgfPlots.Net.Internal.Exceptions;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;

internal class RawDataCollectionNode<TData>: SyntaxNode
{
    public RawDataCollectionNode(IEnumerable<TData> data)
    {
        Children.AddRange(data.Select(d => new RawDataNode<TData>(d)));
    }

    public override void AddChild(SyntaxNode child)
    {
        Type childType = child.GetType();
        if (!childType.IsGenericType || childType.GetGenericArguments() != GetType().GetGenericArguments())
        {
            throw new OneTypeOfDataPerCollectionNodeException<TData>(this, child);
        }
    }

    protected override string BeforeChildren => "{";
    protected override string BetweenChildren => " ";
    protected override string AfterChildren => "}";

    
}