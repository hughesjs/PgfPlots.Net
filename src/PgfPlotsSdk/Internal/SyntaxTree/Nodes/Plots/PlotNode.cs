namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots;

internal class PlotNode: SyntaxNode
{
    protected override string BeforeChildren => """
                                                \addplot
                                                """;

    protected override string BetweenChildren => string.Empty;

    protected override string AfterChildren => ";\n";
}