namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class PlotNode: SyntaxNode
{
    protected override string BeforeChildren => """
                                                \addplot
                                                """;

    protected override string BetweenChildren => string.Empty;

    protected override string AfterChildren => string.Empty;
}