using System.Text;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal abstract class SyntaxNode
{
    public SyntaxNode? Parent { get; }
    public List<SyntaxNode> Children { get; }
    
    protected abstract string BeforeChildren { get; }
    
    protected abstract string AfterChildren { get; }

    public virtual StringBuilder GenerateSource(StringBuilder builder)
    {
        builder.Append(BeforeChildren);
        foreach (SyntaxNode child in Children)
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