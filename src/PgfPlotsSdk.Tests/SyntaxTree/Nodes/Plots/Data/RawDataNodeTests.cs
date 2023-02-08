using AutoFixture;
using PgfPlotsSdk.Internal.Exceptions;
using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Plots.Data;

public class RawDataNodeTests
{
    private readonly Fixture _fixture;

    public RawDataNodeTests()
    {
        _fixture = new();
    }

    [Fact]
    public void ReturnsJustTheDataString()
    {
        Cartesian2<int> coord = _fixture.Create<Cartesian2<int>>();
        RawDataNode node = new(coord);
        PgfPlotSyntaxTree tree = new(node);

        string expected = $"({coord.X},{coord.Y})";
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ThrowsIfITryToAddChildNode()
    {
        RawDataNode node = new(_fixture.Create<Cartesian2<int>>());
        RawDataNode child = new(_fixture.Create<Cartesian2<int>>());
        Should.Throw<NodeIsTerminalException>(() => node.AddChild(child));
    }
    
    [Fact]
    public void ThrowsIfITryToAddChildrenNodes()
    {
        RawDataNode node = new(_fixture.Create<Cartesian2<int>>());
        RawDataNode child1 = new(_fixture.Create<Cartesian2<int>>());
        RawDataNode child2 = new(_fixture.Create<Cartesian2<int>>());
        Should.Throw<NodeIsTerminalException>(() => node.AddChildren(new []{child1, child2}));
    }
}