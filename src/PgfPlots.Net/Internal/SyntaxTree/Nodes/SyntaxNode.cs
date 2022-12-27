using System.Text;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal abstract class SyntaxNode
{
    public SyntaxNode? Parent { get; private set; }
    public List<SyntaxNode> Children { get; }

    public void AddChild(SyntaxNode child)
    {
        // If theres already an options node, we want to merge the options
        OptionsCollectionNode? optionsNode = (OptionsCollectionNode?)Children.SingleOrDefault(c => c is OptionsCollectionNode);
        if (optionsNode is not null && child is OptionsCollectionNode optionsCollectionChild)
        {
            optionsNode.AddChildren(optionsCollectionChild.Children);
        }
        
        child.Parent = this;
        Children.Add(child);
    }

    public void AddChildren(IEnumerable<SyntaxNode> children) => Children.AddRange(children);

    protected abstract string BeforeChildren { get; }
    
    protected abstract string AfterChildren { get; }

    public virtual StringBuilder GenerateSource(StringBuilder builder)
    {
        builder.Append(BeforeChildren);
        
        OptionsCollectionNode? options = (OptionsCollectionNode?)Children.SingleOrDefault(c => c is OptionsCollectionNode);
        options?.GenerateSource(builder);

        foreach (SyntaxNode child in Children.Where(c => c is not OptionsCollectionNode))
        {
            child.GenerateSource(builder);
        }
        builder.Append(AfterChildren);
        return builder;
    }

    protected SyntaxNode()
    {
        Children = new();
    }

    protected SyntaxNode(SyntaxNode parent)
    {
        Parent = parent;
        Children = new();
    }

    protected SyntaxNode(SyntaxNode parent, List<SyntaxNode> children)
    {
        Parent = parent;
        Children = children;
    }
}

internal abstract class SyntaxNode<T>: SyntaxNode
{
    protected T Data { get; }
    
    protected SyntaxNode(T data): base()
    {
        Data = data;
    }

   protected SyntaxNode(SyntaxNode parent, T data): base(parent)
   {
       Data = data;
   }

   protected SyntaxNode(SyntaxNode parent, List<SyntaxNode> children, T data): base(parent, children)
   {
       Data = data;
   }
}