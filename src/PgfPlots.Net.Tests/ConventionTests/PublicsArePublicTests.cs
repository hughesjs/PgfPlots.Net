using PgfPlots.Net.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlots.Net.Tests.ConventionTests;

public class PublicsArePublicTests
{
    private const string PublicNamespaceFragment = "PgfPlots.Net.Public";
    
    [Theory]
    [MemberData(nameof(PublicClassDataGenerator))]
    public void ClassesInPublicNamespaceArePublic(Type type)
    {
        type.IsPublic.ShouldBeTrue();
    }


    public static IEnumerable<object[]> PublicClassDataGenerator() => typeof(AxisOptions).Assembly.GetTypes()
        .Where(t => t.Namespace != null && t.Namespace.Contains(PublicNamespaceFragment))
        .Select(t => new object[] {t});
}