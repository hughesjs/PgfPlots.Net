using System.Numerics;
using System.Text;
using PgfPlotsSdk.Internal.Exceptions;
using PgfPlotsSdk.Public.Models.Plots.Data;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies.Data;

internal class RawSliceNode<T>: SyntaxNode<PieChartSliceData<T>> where T: INumber<T>
{
	public RawSliceNode(PieChartSliceData<T> data) : base(data) { }
	protected override string BeforeChildren => string.Empty;
	protected override string BetweenChildren => string.Empty;
	protected override string AfterChildren => string.Empty;
    
	public override void AddChild(SyntaxNode child) => throw new NodeIsTerminalException(this);

	public override void AddChildren(IEnumerable<SyntaxNode> children) => throw new NodeIsTerminalException(this);

	public override StringBuilder GenerateSource(StringBuilder builder)
	{
		return builder.Append(Data.GetDataLatexString());
	}
}