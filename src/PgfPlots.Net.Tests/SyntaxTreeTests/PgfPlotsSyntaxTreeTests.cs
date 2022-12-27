using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Enums;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests;

public class PgfPlotsSyntaxTreeTests
{
    [Fact]
    public void CanGeneratePgfPlotAxisWithNoData()
    {
        AxisOptions axisOptions = new()
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
        
        PgfPlotDefinition plotDefinition = new(axisOptions);
        PgfPlotsSyntaxTree tree = new(plotDefinition);

        string expected = $$"""
                            \begin{tikzpicture}
                            \begin{axis}[xlabel={{axisOptions.XLabel}}, ylabel={{axisOptions.YLabel}}, xmin={{axisOptions.XMin}}, ymin={{axisOptions.YMin}}, xmax={{axisOptions.XMax}}, ymax={{axisOptions.YMax}}, minor y tick num={{axisOptions.MinorYTickNumber}}, minor x tick num={{axisOptions.MinorXTickNumber}}, xtick={{{string.Join(',',axisOptions.XTicks)}}}, ytick={{{string.Join(',',axisOptions.YTicks)}}}]
                            \end{axis}
                            \end{tikzpicture}
                            """;
        
        string res = tree.GenerateSource();

        res.ShouldBe(expected);
    }
}