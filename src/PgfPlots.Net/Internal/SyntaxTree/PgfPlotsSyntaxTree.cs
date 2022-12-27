using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using PgfPlots.Net.Public.ElementDefinitions;

namespace PgfPlots.Net.Internal.SyntaxTree;

internal class PgfPlotsSyntaxTree
{
    public PgfPlotsSyntaxTree(SyntaxNode rootNode)
    {
        RootNode = rootNode;
    }
    
    public PgfPlotsSyntaxTree(PgfPlotDefinition definition)
    {
        PgfPlotNode rootNode = new();
        RootNode = rootNode;

        AxisNode axisNode = new();
        OptionsCollectionNode optionsCollectionNode = new();
        
    }

    private SyntaxNode RootNode { get; }

    public string GenerateSource() => RootNode.GenerateSource(new()).ToString();
}