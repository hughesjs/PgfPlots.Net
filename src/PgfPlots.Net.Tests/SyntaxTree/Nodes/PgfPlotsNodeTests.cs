using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTree.Nodes;

public class PgfPlotsNodeTests
{
    [Fact]
    public void GeneratesCorrectSourceWithNoChildren()
    {
        PgfPlotNode node = new();
        PgfPlotSyntaxTree tree = new(node);
        const string expected = """
                                \begin{tikzpicture}
                                
                                \end{tikzpicture}
                                """;

        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }
}