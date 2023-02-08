using PgfPlotsSdk.Internal.SyntaxTree;
using Shouldly;

namespace PgfPlotsSdk.Tests.ConventionTests;

public class InternalsAreNotPublicTests
{
    private const string PublicNamespaceFragment = "PgfPlotsSdk.Internal";
    
    [Theory]
    [MemberData(nameof(PublicClassDataGenerator))]
    public void ClassesInInternalsNamespaceAreNotPublic(Type type)
    {
        type.IsPublic.ShouldBeFalse();
    }


    public static IEnumerable<object[]> PublicClassDataGenerator() => typeof(PgfPlotSyntaxTree).Assembly.GetTypes()
        .Where(t => t.Namespace != null && t.Namespace.Contains(PublicNamespaceFragment))
        .Select(t => new object[] {t});
}