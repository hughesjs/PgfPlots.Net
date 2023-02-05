using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Pies.Data;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes;

public class PieNodeTests
{
	
	
	[Fact]
	public void CanGenerateSimplePieChart()
	{
		PieChartOptions options = new()
		{
			PieChartType = PieType.Standard,
			CentrePosition = new(1, 1),
			ReferenceSum = 30
		};

		PieSliceData<int> sliceOne = new(5);
		PieSliceData<int> sliceTwo = new(10);
		PieSliceData<int> sliceThree = new(15);

		const string expected = """
								\pie [standard, pos = {1,1}, sum = 30]{5,10,15}; 
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		

	}
}