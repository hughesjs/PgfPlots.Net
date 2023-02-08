using AutoFixture;
using PgfPlotsSdk.Internal.Reflection;
using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Axes;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Axes;

public class AxisNodeTests
{
    private readonly Fixture _fixture;

    public AxisNodeTests()
    {
        _fixture = new();
    }

    [Fact]
    public void CanGenerateCorrectSourceWithNoOptionsOrPlots()
    {
        AxisNode axisNode = new();
        OptionsCollectionNode optionsNode = new();
        axisNode.AddChild(optionsNode);
        PgfPlotSyntaxTree tree = new(axisNode);
        const string expected = """

                              \begin{axis}
                              \end{axis}
                              """;

        string source = tree.GenerateSource();

        source.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceForSemiLogXWithNoOptionsOrPlots()
    {
        AxisNode axisNode = new(AxisType.SemiLogX);
        OptionsCollectionNode optionsNode = new();
        axisNode.AddChild(optionsNode);
        PgfPlotSyntaxTree tree = new(axisNode);
        const string expected = """

                              \begin{semilogxaxis}
                              \end{semilogxaxis}
                              """;

        string source = tree.GenerateSource();

        source.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceForSemiLogYWithNoOptionsOrPlots()
    {
        AxisNode axisNode = new(AxisType.SemiLogY);
        OptionsCollectionNode optionsNode = new();
        axisNode.AddChild(optionsNode);
        PgfPlotSyntaxTree tree = new(axisNode);
        const string expected = """

                              \begin{semilogyaxis}
                              \end{semilogyaxis}
                              """;

        string source = tree.GenerateSource();

        source.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceForLogLogWithNoOptionsOrPlots()
    {
        AxisNode axisNode = new(AxisType.LogLog);
        OptionsCollectionNode optionsNode = new();
        axisNode.AddChild(optionsNode);
        PgfPlotSyntaxTree tree = new(axisNode);
        const string expected = """

                              \begin{loglogaxis}
                              \end{loglogaxis}
                              """;

        string source = tree.GenerateSource();

        source.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceWithOptionsButNoPlots()
    {
        AxisOptions axis = _fixture.Create<AxisOptions>();
        Dictionary<string, string?> optionsDict = axis.GetOptionsDictionary();

        
        OptionsCollectionNode optionsCollectionNode = new();
        IEnumerable<OptionNode> optionsNodes = optionsDict.Select(option => new OptionNode(option));
        optionsCollectionNode.AddChildren(optionsNodes);
        
        AxisNode axisNode = new();
        axisNode.AddChild(optionsCollectionNode);

        PgfPlotSyntaxTree tree = new(axisNode);
        
        string expected = $$"""

                            \begin{axis}[xlabel={{axis.XLabel}}, ylabel={{axis.YLabel}}, xmin={{axis.XMin}}, ymin={{axis.YMin}}, xmax={{axis.XMax}}, ymax={{axis.YMax}}, minor y tick num={{axis.MinorYTickNumber}}, minor x tick num={{axis.MinorXTickNumber}}, xtick={{{string.Join(',', axis.XTicks!)}}}, ytick={{{string.Join(',', axis.YTicks!)}}}, grid={{PgfPlotsAttributeHelper.GetPgfPlotsKey<GridSetting>(axis.Grid.ToString()!)}}]
                            \end{axis}
                            """;

        string result = tree.GenerateSource();

        result.ShouldBe(expected);
    }
}