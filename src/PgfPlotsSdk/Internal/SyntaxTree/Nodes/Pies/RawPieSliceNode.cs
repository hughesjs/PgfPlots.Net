using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Pies;
using PgfPlotsSdk.Public.ElementDefinitions.Pies.Data;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;

public class RawSliceNode<T>: SyntaxNode<PieSliceData<T>> where T: INumber<T>
{
	public RawSliceNode(PieSliceData<T> data) : base(data) { }
	protected override string BeforeChildren { get; }
	protected override string BetweenChildren { get; }
	protected override string AfterChildren { get; }
}