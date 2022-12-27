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
        AxisDefinition axisDefinition = new()
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
        
        PgfPlotDefinition plotDefinition = new(axisDefinition);
        PgfPlotsSyntaxTree tree = new(plotDefinition);

        string expected = $$"""
                            \begin{tikzpicture}
                            \begin{axis}[xlabel={{axisDefinition.XLabel}}, ylabel={{axisDefinition.YLabel}}, xmin={{axisDefinition.XMin}}, ymin={{axisDefinition.YMin}}, xmax={{axisDefinition.XMax}}, ymax={{axisDefinition.YMax}}, minor y tick num={{axisDefinition.MinorYTickNumber}}, minor x tick num={{axisDefinition.MinorXTickNumber}}, xtick={{{string.Join(',',axisDefinition.XTicks)}}}, ytick={{{string.Join(',',axisDefinition.YTicks)}}}]
                            \end{axis}
                            \end{tikzpicture}
                            """;
        
        string res = tree.GenerateSource();

        res.ShouldBe(expected);
    }
}