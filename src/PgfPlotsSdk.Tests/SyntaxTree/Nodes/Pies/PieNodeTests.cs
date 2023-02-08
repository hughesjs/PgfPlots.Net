using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies.Data;
using PgfPlotsSdk.Public.Models.Enums;
using PgfPlotsSdk.Public.Models.Options;
using PgfPlotsSdk.Public.Models.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Pies;

public class PieNodeTests
{
	private static readonly PieChartSliceData<int> ChartSliceOne = new(5);
	private static readonly PieChartSliceData<int> ChartSliceTwo = new(10);
	private static readonly PieChartSliceData<int> ChartSliceThree = new(15);
	private static readonly RawPieSliceCollectionNode<int> Data = new(ChartSliceOne, ChartSliceTwo, ChartSliceThree);
	
	[Fact]
	public void CanGenerateSimplePieChart()
	{
		PieChartOptions options = new()
		{
			CentrePosition = new(1, 1),
			ReferenceSum = 30,
			Rotation = 90,
			BeforeNumberText = "\\$",
			TextPosition = PieTextOption.Pin,
			HideNumber = true
		};

		const string expected = """

								\pie [pos={1,1}, rotate=90, sum=30, hide number, before number=\$, text=pin]{5, 10, 15};
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		

		PieChartNode pieNode = new();
		pieNode.AddChild(optionsCollectionNode);
		pieNode.AddChild(Data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}

	[Fact]
	public void CanGeneratePolarPieChart()
	{
		PieChartOptions options = new()
		{
			PieChartType = PieType.Polar
		};
		
		const string expected = """

								\pie [polar]{5, 10, 15};
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		

		PieChartNode pieNode = new();
		pieNode.AddChild(optionsCollectionNode);
		pieNode.AddChild(Data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanGenerateCloudPieChart()
	{
		PieChartOptions options = new()
		{
			PieChartType = PieType.Cloud
		};
		
		const string expected = """

								\pie [cloud]{5, 10, 15};
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		

		PieChartNode pieNode = new();
		pieNode.AddChild(optionsCollectionNode);
		pieNode.AddChild(Data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanGenerateSquarePieChart()
	{
		PieChartOptions options = new()
		{
			PieChartType = PieType.Square
		};
		
		const string expected = """

								\pie [square]{5, 10, 15};
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		

		PieChartNode pieNode = new();
		pieNode.AddChild(optionsCollectionNode);
		pieNode.AddChild(Data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanGenerateExplodedPieChart()
	{
		PieChartOptions options = new()
		{
			SliceExplosionFactors = new(){0.1f, 0.2f, 0.3f}
		};
		
		const string expected = """

								\pie [explode={0.1,0.2,0.3}]{5, 10, 15};
								""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		

		PieChartNode pieNode = new();
		pieNode.AddChild(optionsCollectionNode);
		pieNode.AddChild(Data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanGeneratePieChartWithLabels()
	{
		PieChartSliceData<int> sliceOne = new(52, "People who believe anything they're told");
		PieChartSliceData<int> sliceTwo = new(48, "People who understand basic economics");
		RawPieSliceCollectionNode<int> data = new(sliceOne, sliceTwo);
		
		const string expected = """

								\pie {52/{People who believe anything they're told}, 48/{People who understand basic economics}};
								""";
		
		PieChartNode pieNode = new();
		pieNode.AddChild(data);

		PgfPlotSyntaxTree tree = new(pieNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
}