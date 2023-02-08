using System.Text;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Wrappers;

internal class FigureNode: SyntaxNode<FigureDefinition>
{
	protected override string BeforeChildren => "\\begin{figure}";
	protected override string BetweenChildren => string.Empty;
	protected override string AfterChildren => "\n\\end{figure}";

	public FigureNode(FigureDefinition data) : base(data) { }

	public override StringBuilder GenerateSource(StringBuilder builder)
	{
		builder.Append(BeforeChildren);
		foreach (SyntaxNode child in Children)
		{
			child.GenerateSource(builder);
			builder.Append(BetweenChildren);
		}

		if (Data.Caption is not null)
		{
			builder.Append($"\n\\caption{{{Data.Caption}}}");
		}
		
		if (Data.Label is not null)
		{
			builder.Append($"\n\\label{{{Data.Label}}}");
		}
		
		return builder.Append(AfterChildren);
	}
}