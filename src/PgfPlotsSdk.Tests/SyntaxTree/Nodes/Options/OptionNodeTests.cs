using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Internal.SyntaxTree.Nodes.Options;
using Shouldly;

namespace PgfPlotsSdk.Tests.SyntaxTree.Nodes.Options;

public class OptionNodeTests
{
    [Fact]
    public void CanGenerateCorrectSourceForKeyAndValue()
    {
        OptionNode node = new(new("key", "value"));
        const string expected = "key=value";

        PgfPlotSyntaxTree tree = new(node);
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void CanGenerateCorrectSourceForKeyOnly()
    {
        OptionNode node = new(new("key", null));
        const string expected = "key";

        PgfPlotSyntaxTree tree = new(node);
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }
}