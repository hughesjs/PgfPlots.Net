using System.Text;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class OptionNode: SyntaxNode<KeyValuePair<string, string?>>
{
    protected override string BeforeChildren => string.Empty;
    protected override string AfterChildren => ", ";

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

    public OptionNode(KeyValuePair<string, string> data) : base(data) { }
}