using AutoFixture;
using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests.Nodes;

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
        LatexSyntaxTree tree = new(axisNode);
        const string expected = """
                              \begin{axis}[]

                              \end{axis}
                              """;

        string source = tree.GenerateSource();

        source.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceWithOptionsButNoPlots()
    {
        AxisDefinition axis = _fixture.Create<AxisDefinition>();
        Dictionary<string, string?> optionsDict = axis.GetOptionsDictionary();

        
        OptionsCollectionNode optionsCollectionNode = new();
        IEnumerable<OptionNode> optionsNodes = optionsDict.Select(option => new OptionNode(option));
        optionsCollectionNode.AddChildren(optionsNodes);
        
        AxisNode axisNode = new();
        axisNode.AddChild(optionsCollectionNode);

        LatexSyntaxTree tree = new(axisNode);
        
        string expected = $$"""
                            \begin{axis}[xlabel={{axis.XLabel}}, ylabel={{axis.YLabel}}, xmin={{axis.XMin}}, ymin={{axis.YMin}}, xmax={{axis.XMax}}, ymax={{axis.YMax}}, minor y tick no={{axis.MinorYTickNumber}}, minor x tick no={{axis.MinorXTickNumber}}, xticks={{{string.Join(',', axis.XTicks!)}}}, yticks={{{string.Join(',', axis.YTicks!)}}}, grid={{axis.Grid}}, ]

                            \end{axis}
                            """;

        string result = tree.GenerateSource();

        result.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceWithPlotsButNoOptions()
    {
        
    }
    
    [Fact]
    public void CanGenerateCorrectSourceWithBothOptionsAndPlots()
    {
        
    }
}