namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;

internal class PieChartNode: SyntaxNode
{
	protected override string BeforeChildren => """

												\pie 
												""";

	protected override string BetweenChildren => string.Empty;
	protected override string AfterChildren => ";";
}