namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;

public class PieNode: SyntaxNode
{
	protected override string BeforeChildren => """
												\pie
												""";

	protected override string BetweenChildren => string.Empty;
	protected override string AfterChildren => ";\n";
}