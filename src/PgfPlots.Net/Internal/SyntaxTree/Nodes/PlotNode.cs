namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class PlotNode: SyntaxNode
{
    protected override string BeforeChildren { get; }
    protected override string AfterChildren { get; }
}