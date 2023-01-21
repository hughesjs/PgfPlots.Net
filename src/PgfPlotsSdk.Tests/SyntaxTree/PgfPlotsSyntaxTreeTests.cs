using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Public.ElementDefinitions;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree;

public class PgfPlotsSyntaxTreeTests
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

    private static readonly List<Cartesian2<int>> Data1 = new()
    {
        new(0,1),
        new(2,3),
        new(4,5)
    };
    
    private static readonly List<Cartesian2<int>> Data2 = new()
    {
        new(5,6),
        new(7,8),
        new(8,2)
    };
    
    [Fact]
    public void CanGeneratePgfPlotAxisWithNoData()
    {
        PgfPlotDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard);
        PgfPlotSyntaxTree tree = new(pgfPlotDefinition);

        string expected = $$"""
                            \begin{tikzpicture}
                            \begin{axis}[xlabel={{AxisOptions.XLabel}}, ylabel={{AxisOptions.YLabel}}, xmin={{AxisOptions.XMin}}, ymin={{AxisOptions.YMin}}, xmax={{AxisOptions.XMax}}, ymax={{AxisOptions.YMax}}, minor y tick num={{AxisOptions.MinorYTickNumber}}, minor x tick num={{AxisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',AxisOptions.XTicks!)}}}, ytick={{{string.Join(',',AxisOptions.YTicks!)}}}]
                            \end{axis}
                            \end{tikzpicture}
                            """;
        
        string res = tree.GenerateSource();

        res.ShouldBe(expected);
    }

    [Fact]
    public void CanGeneratePgfPlotAxisWithSinglePlot()
    {
        PlotOptions plotOptions = new()
        {
            Colour = LatexColour.Black,
            Mark = PlotMark.Diamond,
            MarkSize = 5,
            LineStyle = LineStyle.Dashed,
            LineWidth = 2f,
            Smooth = true,
            OnlyMarks = false
        };
        PlotDefinition plotDefinition = new(plotOptions, Data1);
        PgfPlotDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard, new(){plotDefinition});
        PgfPlotSyntaxTree tree = new(pgfPlotDefinition);

        string expected = $$"""
                            \begin{tikzpicture}
                            \begin{axis}[xlabel={{AxisOptions.XLabel}}, ylabel={{AxisOptions.YLabel}}, xmin={{AxisOptions.XMin}}, ymin={{AxisOptions.YMin}}, xmax={{AxisOptions.XMax}}, ymax={{AxisOptions.YMax}}, minor y tick num={{AxisOptions.MinorYTickNumber}}, minor x tick num={{AxisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',AxisOptions.XTicks!)}}}, ytick={{{string.Join(',',AxisOptions.YTicks!)}}}]
                            \addplot[color=black, mark=diamond, mark size=5, line width=2, dashed, smooth]
                            plot coordinates {(0,1) (2,3) (4,5)};
                            \end{axis}
                            \end{tikzpicture}
                            """;
        
        string res  = tree.GenerateSource();

        res.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGeneratePgfPlotAxisWithTwoPlots()
    {
        PlotOptions plotOptions1 = new()
        {
            Colour = LatexColour.Black,
            Mark = PlotMark.Diamond,
            MarkSize = 5,
            LineStyle = LineStyle.Dashed,
            LineWidth = 2f,
            Smooth = true,
            OnlyMarks = false
        };
        
        PlotOptions plotOptions2 = new()
        {
            Colour = LatexColour.Blue,
            Mark = PlotMark.Triangle,
            MarkSize = 1,
            LineStyle = LineStyle.Solid,
            LineWidth = 1f
        };
        PlotDefinition plotDefinition1 = new(plotOptions1, Data1);
        PlotDefinition plotDefinition2 = new(plotOptions2, Data2);
        
        PgfPlotDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard, new(){plotDefinition1, plotDefinition2});
        PgfPlotSyntaxTree tree = new(pgfPlotDefinition);

        string expected = $$"""
                            \begin{tikzpicture}
                            \begin{axis}[xlabel={{AxisOptions.XLabel}}, ylabel={{AxisOptions.YLabel}}, xmin={{AxisOptions.XMin}}, ymin={{AxisOptions.YMin}}, xmax={{AxisOptions.XMax}}, ymax={{AxisOptions.YMax}}, minor y tick num={{AxisOptions.MinorYTickNumber}}, minor x tick num={{AxisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',AxisOptions.XTicks!)}}}, ytick={{{string.Join(',',AxisOptions.YTicks!)}}}]
                            \addplot[color=black, mark=diamond, mark size=5, line width=2, dashed, smooth]
                            plot coordinates {(0,1) (2,3) (4,5)};
                            \addplot[color=blue, mark=triangle, mark size=1, line width=1, solid]
                            plot coordinates {(5,6) (7,8) (8,2)};
                            \end{axis}
                            \end{tikzpicture}
                            """;
        
        string res  = tree.GenerateSource();

        res.ShouldBe(expected);
    }
    
    //Multiple plots
}