using PgfPlotsSdk.Internal.SyntaxTree.Nodes;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Axes;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots.Data;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Wrappers;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

namespace PgfPlotsSdk.Internal.SyntaxTree;

internal class PgfPlotSyntaxTree
{
    public PgfPlotSyntaxTree(SyntaxNode rootNode)
    {
        RootNode = rootNode;
    }
    
    public PgfPlotSyntaxTree(PgfPlotDefinition definition)
    {
        RootNode = GenerateTree(definition);
    }

    public PgfPlotSyntaxTree(FigureDefinition definition)
    {
        RootNode = GenerateTree(definition);
    }

    private SyntaxNode GenerateTree(FigureDefinition definition)
    {
        PgfPlotNode[] pgfPlotNodes = definition.Plots?.Select(GenerateTree).ToArray() ?? Array.Empty<PgfPlotNode>();

        FigureNode rootNode = new(definition);
        rootNode.AddChildren(pgfPlotNodes);

        return rootNode;
    }

    private PgfPlotNode GenerateTree(PgfPlotDefinition definition)
    {
        AxisNode axisNode = new(definition.AxisType);
        
        OptionsCollectionNode optionsCollectionNode = new(definition.AxisOptions.GetOptionsDictionary());
        axisNode.AddChild(optionsCollectionNode);
        
        List<PlotNode> plotNodes = definition.PlotDefinitions.Select(GeneratePlotNode).ToList();
        axisNode.AddChildren(plotNodes);
        
        PgfPlotNode rootNode = new();
        rootNode.AddChild(axisNode);

        return rootNode;
    }

    private PlotNode GeneratePlotNode(PlotDefinition plotDefinition)
    {
        PlotNode plotNode = GenerateNodeWithOptions<PlotNode>(plotDefinition.PlotOptions);
        RawDataCollectionNode dataCollectionNode = new(plotDefinition.PlotData);
        plotNode.AddChild(dataCollectionNode);
        return plotNode;
    }
    
    private TNode GenerateNodeWithOptions<TNode>(OptionsDefinition options) where TNode: SyntaxNode, new()
    {
        TNode node = new();
        OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
        node.AddChild(optionsCollectionNode);
        return node;
    }

    private SyntaxNode RootNode { get; }

    public string GenerateSource() => RootNode.GenerateSource(new()).ToString();
}