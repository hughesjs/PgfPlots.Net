using AutoFixture;
using PgfPlots.Net.Internal.Exceptions;
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
        PgfPlotsSyntaxTree tree = new(node);
        
        const string expected = "[]\n";
        string result = tree.GenerateSource();

        result.ShouldBe(expected);
    }

    [Fact]
    public void CanGenerateCorrectSourceWithChildOptions()
    {
        Dictionary<string, string> propsDict = _fixture.Create<Dictionary<string, string>>();
        string expected = $"[{string.Join(", ", propsDict.Select(kvp => $"{kvp.Key}={kvp.Value}"))}]\n";
        
        OptionsCollectionNode optionsCollectionNode = new(propsDict);

        PgfPlotsSyntaxTree tree = new(optionsCollectionNode);
        string result = tree.GenerateSource();
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ThrowsIfYouTryToAddNonOptionsNodeAsChild()
    {
        OptionsCollectionNode optionCollectionNode = new();
        PgfPlotNode susNode = new();

        Should.Throw<OptionsCollectionNodesCanOnlyHaveOptionNodesAsChildrenException>(() => optionCollectionNode.AddChild(susNode));
    }

    [Fact]
    public void ThrowsIfYouTryToAddNonOptionsNodesAsChildren()
    {
        OptionsCollectionNode optionsCollectionNode = new();
        IEnumerable<OptionNode> validOptionNodes = _fixture.CreateMany<OptionNode>();
        PgfPlotNode susNode = new();
        
        List<SyntaxNode> children = new();
        children.AddRange(validOptionNodes);
        children.Add(susNode);

        Should.Throw<OptionsCollectionNodesCanOnlyHaveOptionNodesAsChildrenException>(() =>
            optionsCollectionNode.AddChildren(children));
    }
}