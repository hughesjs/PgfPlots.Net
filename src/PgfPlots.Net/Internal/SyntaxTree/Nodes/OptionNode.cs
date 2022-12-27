using System.Text;
using PgfPlots.Net.Internal.Exceptions;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

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

    public override void AddChild(SyntaxNode child) => throw new OptionNodeIsTerminalException();

    public override void AddChildren(IEnumerable<SyntaxNode> children) => throw new OptionNodeIsTerminalException();

    public OptionNode(KeyValuePair<string, string?> data) : base(data) { }
}