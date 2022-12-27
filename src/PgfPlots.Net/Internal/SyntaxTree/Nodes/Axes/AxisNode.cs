namespace PgfPlots.Net.Internal.SyntaxTree.Nodes.Axes;

internal class AxisNode : SyntaxNode
{
    protected override string BeforeChildren => """
                                                \begin{axis}
                                                """;

    protected override string AfterChildren => """
                                               \end{axis}
                                               """;

    protected override string BetweenChildren => string.Empty;
}