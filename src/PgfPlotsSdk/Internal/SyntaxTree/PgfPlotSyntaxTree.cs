using PgfPlotsSdk.Internal.SyntaxTree.Nodes;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Axes;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies.Data;
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
        PgfPlotNode rootNode = new();
        List<SyntaxNode> plotNodes = definition.PlotDefinitions.Select(GenerateContentNode).ToList();
        
        if (definition is PgfPlotWithAxesDefinition plotWithAxesDefinition)
        {
            AxisNode axisNode = new(plotWithAxesDefinition.AxisType);
            OptionsCollectionNode optionsCollectionNode = new(plotWithAxesDefinition.AxisOptions.GetOptionsDictionary());
            axisNode.AddChild(optionsCollectionNode);
            axisNode.AddChildren(plotNodes);
            rootNode.AddChild(axisNode);
        }
        else
        {
            rootNode.AddChildren(plotNodes);
        }
        
        return rootNode;
    }

    private PlotNode GeneratePlotNode(PlotDefinition plotDefinition)
    {
        PlotNode plotNode = GenerateNodeWithOptions<PlotNode>(plotDefinition.PlotOptions);
        RawDataCollectionNode dataCollectionNode = new(plotDefinition.PlotData);
        plotNode.AddChild(dataCollectionNode);
        return plotNode;
    }

    private SyntaxNode GenerateContentNode(PlotDefinition plotDefinition)
    {
        if (plotDefinition.PlotOptions is PieChartOptions)
        {
            return GeneratePieChartNode(plotDefinition);
        }

        if (plotDefinition.PlotOptions is PlotOptions)
        {
            return GeneratePlotNode(plotDefinition);
        }

        throw new($"This option type hasn't been implemented yet {plotDefinition.PlotOptions.GetType()}");
    }

    private SyntaxNode GeneratePieChartNode(PlotDefinition plotDefinition)
    {
        PieChartNode plotNode = GenerateNodeWithOptions<PieChartNode>(plotDefinition.PlotOptions);
        // Replace this with something less gross...
        Type unconstructedCollectionNodeType = typeof(RawPieSliceCollectionNode<>);
        Type constructedCollectionNodeType = unconstructedCollectionNodeType.MakeGenericType(plotDefinition.PlotData.First().GetType().GetGenericArguments());
        SyntaxNode dataCollectionNode = (SyntaxNode)Activator.CreateInstance(constructedCollectionNodeType, plotDefinition.PlotData.Cast<object>().ToArray())!;
        plotNode.AddChild(dataCollectionNode!);
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