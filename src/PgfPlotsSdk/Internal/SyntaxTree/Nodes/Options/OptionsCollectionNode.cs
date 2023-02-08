using PgfPlotsSdk.Internal.Exceptions;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;

internal class OptionsCollectionNode: SyntaxNode
{
    protected override string BeforeChildren => "[";
    protected override string BetweenChildren => ", ";
    protected override string AfterChildren => "]\n";

    public override void AddChild(SyntaxNode child)
    {
        if (child is not OptionNode)
        {
            throw new OptionsCollectionNodesCanOnlyHaveOptionNodesAsChildrenException();
        }
        base.AddChild(child);   
    }

    public OptionsCollectionNode(){}
    
    public OptionsCollectionNode(Dictionary<string, string?> optionsDict)
    {
        IEnumerable<OptionNode> optionNodes = optionsDict.Select(option => new OptionNode(option));
        base.AddChildren(optionNodes);
    }
}