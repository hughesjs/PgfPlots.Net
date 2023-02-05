using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Pies;

public class PieNodeTests
{
	
	
	[Fact]
	public void CanGenerateSimplePieChart()
	{
		PieChartOptions options = new()
		{
			CentrePosition = new(1, 1),
			ReferenceSum = 30
		};

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);

		const string expected = """
								\pie[pos={1,1}, sum=30]
								{5, 10, 15};
								
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		RawPieSliceCollectionNode<int> data = new(new[] { chartSliceOne, chartSliceTwo, chartSliceThree });

		PieChartNode pieNode = new();
		pieNode.AddChild(optionsCollectionNode);
		pieNode.AddChild(data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
}