using PgfPlots.Net.Internal.SyntaxTree.Nodes;

namespace PgfPlots.Net.Internal.SyntaxTree;

internal class LatexSyntaxTree
{
    public LatexSyntaxTree(SyntaxNode rootNode)
    {
        RootNode = rootNode;
    }

    private SyntaxNode RootNode { get; }

    public string GenerateSource() => RootNode.GenerateSource(new()).ToString();
}