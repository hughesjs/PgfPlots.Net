using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;
using PgfPlotsSdk.Public.Interfaces.Data;
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

    private static readonly ILatexData[] Data1 = {
        new Cartesian2<int>(0,1),
        new Cartesian2<int>(2,3),
        new Cartesian2<int>(4,5)
    };
    
    private static readonly ILatexData[] Data2 = {
        new Cartesian2<int>(5,6),
        new Cartesian2<int>(7,8),
        new Cartesian2<int>(8,2)
    };
    
    [Fact]
    public void CanGeneratePgfPlotAxisWithNoData()
    {
        PgfPlotWithAxesDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard);
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
        PgfPlotWithAxesDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard, plotDefinition);
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
        
        PgfPlotWithAxesDefinition pgfPlotDefinition = new(AxisOptions, AxisType.Standard, plotDefinition1, plotDefinition2);
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

    [Fact]
    public void CanGeneratePgfPlotWithSinglePieChart()
    {
        PieChartOptions options = new()
        {
            CentrePosition = new(1, 1),
            ReferenceSum = 30,
            AfterNumberText = @"\%",
            Radius = 2.3f,
            PieChartType = PieType.Polar,
            ScaleFont = true,
            SliceColours = new() { LatexColour.Red, LatexColour.Green, LatexColour.Blue}
        };
        
        PieChartSliceData<int> chartSliceOne = new(5);
        PieChartSliceData<int> chartSliceTwo = new(10);
        PieChartSliceData<int> chartSliceThree = new(15);
        PlotDefinition<PieChartOptions> pieChartDefinition = new(options, chartSliceOne, chartSliceTwo, chartSliceThree);

        PgfPlotDefinition plotDefinition = new(pieChartDefinition);
        PgfPlotSyntaxTree tree = new(plotDefinition);
        
        const string expected = """
                                \begin{tikzpicture}
                                \pie [polar, pos={1,1}, radius=2.3, color={red,green,blue}, sum=30, scale font, after number=\%]
                                {5, 10, 15};

                                \end{tikzpicture}
                                """;
        
        string res  = tree.GenerateSource();

        res.ShouldBe(expected);
    }
}