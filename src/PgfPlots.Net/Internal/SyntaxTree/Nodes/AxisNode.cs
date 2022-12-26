namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class AxisNode : SyntaxNode
{
    protected override string BeforeChildren => """
                                                \begin{axis}
                                                """;

    protected override string AfterChildren => """
                                               
                                               \end{axis}
                                               """;
}