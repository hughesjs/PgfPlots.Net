using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Wrappers;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;
using PgfPlotsSdk.Public.Interfaces.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Wrappers;

public class FigureNodeTests
{
	private static readonly AxisOptions AxisOptions = new()
	{
		XMin = -5,
		XMax = 5,
		XTicks = new() {-5, -3.2f, -1, 0, 1.2f, 4, 5},
		YMin = 0,
		YMax = 10,
		YTicks = new() {0, 3.3f, 6.2f, 8, 9, 10},
		MinorXTickNumber = 3,
		MinorYTickNumber = 4,
		XLabel = "I Am The X Label",
		YLabel = "I Am The Y Label"
	};

	private static readonly PlotOptions PlotOptions = new()
	{
		Colour = LatexColour.Black,
		Mark = PlotMark.Diamond,
		MarkSize = 5,
		LineStyle = LineStyle.Dashed,
		LineWidth = 2f,
		Smooth = true,
		OnlyMarks = false
	};

	private static readonly ILatexData[] Data = {
		new Cartesian2<int>(0,1),
		new Cartesian2<int>(2,3),
		new Cartesian2<int>(4,5)
	};

	private const string Label = "IAmTheLabel";
	private const string Caption = "IAmTheCaption";
	
	[Fact]
	public void CanGenerateCorrectSourceWithNoContent()
	{
		const string expected = $$"""
							\begin{figure}
							\caption{{{Caption}}}
							\label{{{Label}}}
							\end{figure}

							""";

		FigureDefinition figureDefinition = new()
		{
			Caption = Caption,
			Label = Label
		};

		FigureNode node = new(figureDefinition);
		PgfPlotSyntaxTree tree = new(node);

		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}

	[Fact]
	public void CanGenerateCorrectSourceWithOnePlot()
	{
		string expected = $$"""
							\begin{figure}
							\begin{tikzpicture}
							\begin{axis}[xlabel={{AxisOptions.XLabel}}, ylabel={{AxisOptions.YLabel}}, xmin={{AxisOptions.XMin}}, ymin={{AxisOptions.YMin}}, xmax={{AxisOptions.XMax}}, ymax={{AxisOptions.YMax}}, minor y tick num={{AxisOptions.MinorYTickNumber}}, minor x tick num={{AxisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',AxisOptions.XTicks!)}}}, ytick={{{string.Join(',',AxisOptions.YTicks!)}}}]
							\addplot[color=black, mark=diamond, mark size=5, line width=2, dashed, smooth]
							plot coordinates {(0,1) (2,3) (4,5)};
							\end{axis}
							\end{tikzpicture}
							\caption{{{Caption}}}
							\label{{{Label}}}
							\end{figure}

							""";
		
		PlotDefinition plotDefinition = new(PlotOptions, Data);
		PgfPlotWithAxesDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard, plotDefinition);
        FigureDefinition figureDefinition = new()
        {
	        Caption = Caption,
	        Label = Label,
	        Plots = new(){pgfPlotDefinition}
        };
        
		PgfPlotSyntaxTree tree = new(figureDefinition);
		
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}

	[Fact]
	public void CanGenerateCorrectSourceWithMultiplePlots()
	{
		string expected = $$"""
							\begin{figure}
							\begin{tikzpicture}
							\begin{axis}[xlabel={{AxisOptions.XLabel}}, ylabel={{AxisOptions.YLabel}}, xmin={{AxisOptions.XMin}}, ymin={{AxisOptions.YMin}}, xmax={{AxisOptions.XMax}}, ymax={{AxisOptions.YMax}}, minor y tick num={{AxisOptions.MinorYTickNumber}}, minor x tick num={{AxisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',AxisOptions.XTicks!)}}}, ytick={{{string.Join(',',AxisOptions.YTicks!)}}}]
							\addplot[color=black, mark=diamond, mark size=5, line width=2, dashed, smooth]
							plot coordinates {(0,1) (2,3) (4,5)};
							\end{axis}
							\end{tikzpicture}
							\begin{tikzpicture}
							\begin{axis}[xlabel={{AxisOptions.XLabel}}, ylabel={{AxisOptions.YLabel}}, xmin={{AxisOptions.XMin}}, ymin={{AxisOptions.YMin}}, xmax={{AxisOptions.XMax}}, ymax={{AxisOptions.YMax}}, minor y tick num={{AxisOptions.MinorYTickNumber}}, minor x tick num={{AxisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',AxisOptions.XTicks!)}}}, ytick={{{string.Join(',',AxisOptions.YTicks!)}}}]
							\addplot[color=black, mark=diamond, mark size=5, line width=2, dashed, smooth]
							plot coordinates {(0,1) (2,3) (4,5)};
							\end{axis}
							\end{tikzpicture}
							\caption{{{Caption}}}
							\label{{{Label}}}
							\end{figure}

							""";
		
		PlotDefinition plotDefinition = new(PlotOptions, Data);
		PgfPlotWithAxesDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard, plotDefinition);
		FigureDefinition figureDefinition = new()
		{
			Caption = Caption,
			Label = Label,
			Plots = new(){pgfPlotDefinition, pgfPlotDefinition}
		};
        
		PgfPlotSyntaxTree tree = new(figureDefinition);
		
		string res = tree.GenerateSource();
		
		res.ShouldBe(expected);
	}
}