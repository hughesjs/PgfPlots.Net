namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class OptionsCollectionNode: SyntaxNode
{
    protected override string BeforeChildren => "[";
    protected override string BetweenChildren => ", ";
    protected override string AfterChildren => "]\n";

    public override void AddChild(SyntaxNode child)
    {
        if (child is not OptionNode)
        {
            
        }
        base.AddChild(child);   
    }
}