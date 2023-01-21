using PgfPlotsSdk.Internal.Reflection;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Axes;

internal class AxisNode : SyntaxNode<AxisType>
{
    protected override string BeforeChildren => $$"""
												\begin{{{PgfPlotsAttributeHelper.GetPgfPlotsKey<AxisType>(Data.ToString())}}}
												""";

    protected override string AfterChildren => $$"""
                                               \end{{{PgfPlotsAttributeHelper.GetPgfPlotsKey<AxisType>(Data.ToString())}}}
                                               """;

    protected override string BetweenChildren => string.Empty;
    public AxisNode(AxisType data) : base(data) { }

    public AxisNode() : base(AxisType.Standard)
    {
	    
	    string test = $$"""
						\begin{{PgfPlotsAttributeHelper.GetPgfPlotsKey<AxisType>(Data.ToString())}}
						""";
	    ;
    }
}