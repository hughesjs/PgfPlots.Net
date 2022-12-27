using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests.Nodes;

public class OptionNodeTests
{
    [Fact]
    public void CanGenerateCorrectSourceForKeyAndValue()
    {
        OptionNode node = new(new("key", "value"));
        const string expected = "key=value";

        PgfPlotsSyntaxTree tree = new(node);
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void CanGenerateCorrectSourceForKeyOnly()
    {
        OptionNode node = new(new("key", null));
        const string expected = "key";

        PgfPlotsSyntaxTree tree = new(node);
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }
}