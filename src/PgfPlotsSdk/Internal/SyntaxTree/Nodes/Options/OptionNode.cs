using System.Text;
using PgfPlotsSdk.Internal.Exceptions;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;

internal class OptionNode: SyntaxNode<KeyValuePair<string, string?>>
{
    protected override string BeforeChildren => string.Empty;
    protected override string BetweenChildren => string.Empty;
    protected override string AfterChildren => string.Empty;

    public override StringBuilder GenerateSource(StringBuilder builder)
    {
        builder.Append(Data.Key);
        if (Data.Value is not null)
        {
            builder.Append("=");
            builder.Append(Data.Value);
        }

        builder.Append(AfterChildren);
        return builder;
    }

    public override void AddChild(SyntaxNode child) => throw new NodeIsTerminalException(this);

    public override void AddChildren(IEnumerable<SyntaxNode> children) => throw new NodeIsTerminalException(this);

    public OptionNode(KeyValuePair<string, string?> data) : base(data) { }
}