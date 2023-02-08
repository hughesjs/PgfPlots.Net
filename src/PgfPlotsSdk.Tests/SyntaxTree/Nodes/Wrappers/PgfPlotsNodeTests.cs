using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Wrappers;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Wrappers;

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