using PgfPlots.Net.Internal.Exceptions;
using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;
using PgfPlots.Net.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests.Nodes.Plots.Data;

public class RawPlotDataCollectionNodeTests
{
    [Fact]
    public void CanGenerateCorrectSourceWithDataPoints()
    {
        List<Cartesian2<int>> coordinates = new() { new(0, 0), new(1, 2), new(3, 3) };
        RawDataCollectionNode<Cartesian2<int>> collectionNode = new(coordinates);

        PgfPlotsSyntaxTree tree = new(collectionNode);
        string expected = $"{{{string.Join(' ', coordinates)}}}";

        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ThrowsIfYouTryToAddBadDataType()
    {
        List<Cartesian2<int>> coordinates = new() { new(0, 0), new(1, 2), new(3, 3) };
        RawDataCollectionNode<Cartesian2<int>> collectionNode = new(coordinates);

        RawDataNode<double> susNode = new(2.2);

        Should.Throw<OneTypeOfDataPerCollectionNodeException<Cartesian2<int>>>(() => collectionNode.AddChild(susNode));
    }
    
    [Fact]
    public void ThrowsIfYouTryToAddManyOfBadDataType()
    {
        List<Cartesian2<int>> coordinates = new() { new(0, 0), new(1, 2), new(3, 3) };
        RawDataCollectionNode<Cartesian2<int>> collectionNode = new(coordinates);

        RawDataNode<double>[] susNodes = {new(2.2), new(2.2), new(2.2)};

        Should.Throw<OneTypeOfDataPerCollectionNodeException<Cartesian2<int>>>(() => collectionNode.AddChildren(susNodes));
    }
}