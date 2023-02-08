using System.Text;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Wrappers;

internal class FigureNode: SyntaxNode<FigureDefinition>
{
	protected override string BeforeChildren => "\\begin{figure}\n";
	protected override string BetweenChildren => "\n";
	protected override string AfterChildren => "\\end{figure}";

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
			builder.Append($"\\caption{{{Data.Caption}}}\n");
		}
		
		if (Data.Label is not null)
		{
			builder.Append($"\\label{{{Data.Label}}}\n");
		}
		
		return builder.Append(AfterChildren);
	}
}