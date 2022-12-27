using AutoFixture;
using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests.Nodes;

public class OptionCollectionNodeTests
{
    private readonly Fixture _fixture;

    public OptionCollectionNodeTests()
    {
        _fixture = new();
    }

    [Fact]
    public void CanGenerateCorrectSourceWithNoChildOptions()
    {
        OptionsCollectionNode node = new();
        LatexSyntaxTree tree = new(node);
        
        const string expected = "[]\n";
        string result = tree.GenerateSource();

        result.ShouldBe(expected);
    }

    [Fact]
    public void CanGenerateCorrectSourceWithChildOptions()
    {
        Dictionary<string, string> propsDict = _fixture.Create<Dictionary<string, string>>();
        string expected = $"[{string.Join(", ", propsDict.Select(kvp => $"{kvp.Key}={kvp.Value}"))}]\n";
        
        IEnumerable<OptionNode> optionsNodes = propsDict.Select(option => new OptionNode(option));
        OptionsCollectionNode optionsCollectionNode = new();
        optionsCollectionNode.AddChildren(optionsNodes);

        LatexSyntaxTree tree = new(optionsCollectionNode);
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ThrowsIfYouTryToAddNonOptionsNodeAsChild()
    {
        
    }

    [Fact]
    public void ThrowsIfYouTryToAddNonOptionsNodesAsChildren()
    {
        
    }
}