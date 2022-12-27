using System.Text;
using PgfPlots.Net.Internal.Exceptions;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;

internal class RawDataNode<TData>: SyntaxNode<TData>
{
    public RawDataNode(TData data) : base(data) { }

    protected override string BeforeChildren => string.Empty;
    protected override string BetweenChildren => string.Empty;
    protected override string AfterChildren => string.Empty;
    
    public override void AddChild(SyntaxNode child) => throw new NodeIsTerminalException(this);

    public override void AddChildren(IEnumerable<SyntaxNode> children) => throw new NodeIsTerminalException(this);

    public override StringBuilder GenerateSource(StringBuilder builder)
    {
        return builder.Append(Data);
    }
}