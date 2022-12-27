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
        AxisNode axisNode = new();
        OptionsCollectionNode axisOptionsCollectionNode = new(definition.AxisDefinition.GetOptionsDictionary());
        axisNode.AddChild(axisOptionsCollectionNode);
        
        PgfPlotNode rootNode = new();
        rootNode.AddChild(axisNode);
        
        RootNode = rootNode;
    }

    private SyntaxNode RootNode { get; }

    public string GenerateSource() => RootNode.GenerateSource(new()).ToString();
}