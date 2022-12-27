using PgfPlots.Net.Internal.SyntaxTree;
using Shouldly;

namespace PgfPlots.Net.Tests.ConventionTests;

public class InternalsAreNotPublicTests
{
    private const string PublicNamespaceFragment = "PgfPlots.Net.Internal";
    
    [Theory]
    [MemberData(nameof(PublicClassDataGenerator))]
    public void ClassesInInternalsNamespaceAreNotPublic(Type type)
    {
        type.IsPublic.ShouldBeFalse();
    }


    public static IEnumerable<object[]> PublicClassDataGenerator() => typeof(PgfPlotsSyntaxTree).Assembly.GetTypes()
        .Where(t => t.Namespace != null && t.Namespace.Contains(PublicNamespaceFragment))
        .Select(t => new object[] {t});
}