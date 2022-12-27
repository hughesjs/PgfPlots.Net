using PgfPlots.Net.Internal.Exceptions;
using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTree.Nodes.Plots.Data;

public class RawDataNodeTests
{
    [Fact]
    public void ReturnsJustTheDataString()
    {
        RawDataNode node = new(1);
        PgfPlotSyntaxTree tree = new(node);

        string expected = "1";
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ThrowsIfITryToAddChildNode()
    {
        RawDataNode node = new(1);
        RawDataNode child = new(2);
        Should.Throw<NodeIsTerminalException>(() => node.AddChild(child));
    }
    
    [Fact]
    public void ThrowsIfITryToAddChildrenNodes()
    {
        RawDataNode node = new(1);
        RawDataNode child1 = new(2);
        RawDataNode child2 = new(3);
        Should.Throw<NodeIsTerminalException>(() => node.AddChildren(new []{child1, child2}));
    }
}