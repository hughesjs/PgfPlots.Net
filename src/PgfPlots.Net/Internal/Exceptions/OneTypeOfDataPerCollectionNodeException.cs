using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;

namespace PgfPlots.Net.Internal.Exceptions;

internal class OneTypeOfDataPerCollectionNodeException<TDataCollection>: Exception
{
    public OneTypeOfDataPerCollectionNodeException(RawDataCollectionNode<TDataCollection> collectionNode, SyntaxNode illegalNode) : base("All data nodes in a collection must be of the same type")
    {
        CollectionNode = collectionNode;
        IllegalNode = illegalNode;
    }

    public RawDataCollectionNode<TDataCollection> CollectionNode { get; }
    public SyntaxNode IllegalNode { get; }
    
    
}