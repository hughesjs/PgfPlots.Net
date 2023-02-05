using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Pies.Data;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies.Data;

internal class RawPieSliceCollectionNode<T>: SyntaxNode where T : INumber<T>
{
	public RawPieSliceCollectionNode(IEnumerable<PieChartSliceData<T>> data)
	{
		Children.AddRange(data.Select(d => new RawSliceNode<T>(d)));
	}
    
	public RawPieSliceCollectionNode(PieChartSliceData<T> data) // For instances where you've built a collection container already
	{
		Children.Add(new RawSliceNode<T>(data));
	}

	protected override string BeforeChildren => "{";
	protected override string BetweenChildren => ", ";
	protected override string AfterChildren => "}";
}