using PgfPlots.Net.Internal.SyntaxTree.Nodes;

namespace PgfPlots.Net.Internal.Exceptions;

internal class NodeIsTerminalException: Exception
{
    public SyntaxNode Node { get; }
    
    public NodeIsTerminalException(SyntaxNode node) : base($"{node.GetType().Name} nodes can't have children")
    {
        Node = node;
    }
}