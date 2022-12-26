namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class OptionsCollectionNode: SyntaxNode
{
    protected override string BeforeChildren => "[";
    protected override string AfterChildren => "]\n";
}