using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests.Nodes.Plots.Data;

public class RawDataNodeTests
{
    [Fact]
    public void ReturnsJustTheDataString()
    {
        RawDataNode node = new(1);
        PgfPlotsSyntaxTree tree = new(node);

        string expected = "1";
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }
}