using PgfPlotsSdk.Internal.SyntaxTree.Nodes;

namespace PgfPlotsSdk.Internal.Exceptions;

internal class NodeIsTerminalException: Exception
{
    public SyntaxNode Node { get; }
    
    public NodeIsTerminalException(SyntaxNode node) : base($"{node.GetType().Name} nodes can't have children")
    {
        Node = node;
    }
}