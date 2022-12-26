using System.Globalization;
using AutoFixture;
using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Enums;
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
        AxisDefinition definition = new();
        AxisNode node = new(definition);
        LatexSyntaxTree tree = new(node);
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

        AxisNode node = new(axis);
        LatexSyntaxTree tree = new(node);
        
        string expected = $$"""
                            \begin{axis}[xlabel={{axis.XLabel}} ylabel={{axis.YLabel}} xmin={{axis.XMin}} ymin={{axis.YMin}} xmax={{axis.XMax}} ymax={{axis.YMax}} minor y tick no={{axis.MinorYTickNumber}} minor x tick no={{axis.MinorXTickNumber}} xticks={{{string.Join(',', axis.XTicks!)}}} yticks={{{string.Join(',', axis.YTicks!)}}} grid={{axis.Grid}} ]

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