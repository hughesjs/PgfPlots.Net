using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;
using PgfPlots.Net.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTree.Nodes.Plots.Data;

public class RawPlotDataCollectionNodeTests
{
    [Fact]
    public void CanGenerateCorrectSourceWithDataPoints()
    {
        List<Cartesian2<int>> coordinates = new() { new(0, 0), new(1, 2), new(3, 3) };
        RawDataCollectionNode collectionNode = new(coordinates);

        PgfPlotSyntaxTree tree = new(collectionNode);
        string expected = $"plot coordinates {{{string.Join(' ', coordinates)}}}";

        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }
}