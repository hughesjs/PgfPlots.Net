using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Plots;

public class PlotNodeTests
{
	private static readonly List<Cartesian2<int>> Data = new()
	{
		new(0,1),
		new(2,3),
		new(4,5)
	};
	
	[Fact]
	public void CanGenerateSimpleLinePlot()
	{
		PlotOptions options = new()
		{
			Colour = LatexColour.Cyan,
			Mark = PlotMark.Pentagon,
			MarkSize = 0.5f,
			LineWidth = 0.2f,
			OnlyMarks = true,
			Smooth = false
		};

		string expected = """
						\addplot[color=cyan, mark=pentagon, mark size=0.5, line width=0.2, only marks]
						plot coordinates {(0,1) (2,3) (4,5)};

						""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		RawDataCollectionNode rawDataCollectionNode = new(Data);
		
		PlotNode plotNode = new();
		plotNode.AddChild(optionsCollectionNode);
		plotNode.AddChild(rawDataCollectionNode);

		PgfPlotSyntaxTree tree = new(plotNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanGenerateLinePlotWithComplexOptions()
	{
		PlotOptions options = new()
		{
			LineStyle = LineStyle.Dashed,
			Fill = LatexColour.Magenta,
			FillOpacity = 0.2f
		};

		string expected = """
						\addplot[fill opacity=0.2, dashed, fill=magenta]
						plot coordinates {(0,1) (2,3) (4,5)};

						""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		RawDataCollectionNode rawDataCollectionNode = new(Data);
		
		PlotNode plotNode = new();
		plotNode.AddChild(optionsCollectionNode);
		plotNode.AddChild(rawDataCollectionNode);

		PgfPlotSyntaxTree tree = new(plotNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanGenerateXBarChart()
	{
		PlotOptions options = new()
		{
			Colour = LatexColour.Green,
			Fill = LatexColour.Red,
			FillOpacity = 0.4f,
			BarType = BarType.XBar
		};
		
		string expected = """
						\addplot[color=green, fill opacity=0.4, xbar, fill=red]
						plot coordinates {(0,1) (2,3) (4,5)};

						""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		RawDataCollectionNode rawDataCollectionNode = new(Data);
		
		PlotNode plotNode = new();
		plotNode.AddChild(optionsCollectionNode);
		plotNode.AddChild(rawDataCollectionNode);

		PgfPlotSyntaxTree tree = new(plotNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}

	[Fact]
	public void CanGenerateYBarChart()
	{
		PlotOptions options = new()
		{
			Colour = LatexColour.Green,
			Fill = LatexColour.Red,
			FillOpacity = 0.4f,
			BarType = BarType.YBar
		};
		
		string expected = """
						\addplot[color=green, fill opacity=0.4, ybar, fill=red]
						plot coordinates {(0,1) (2,3) (4,5)};

						""";
		
		OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
		RawDataCollectionNode rawDataCollectionNode = new(Data);
		
		PlotNode plotNode = new();
		plotNode.AddChild(optionsCollectionNode);
		plotNode.AddChild(rawDataCollectionNode);

		PgfPlotSyntaxTree tree = new(plotNode);
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
}



