using System.Reflection;
using System.Runtime.CompilerServices;
using PgfPlotsSdk.Public.Models.Options;
using Shouldly;

namespace PgfPlotsSdk.Tests.ConventionTests;

public class PublicsArePublicTests
{
    private const string PublicNamespaceFragment = "PgfPlotsSdk.Public";
    
    [Theory]
    [MemberData(nameof(PublicClassDataGenerator))]
    public void ClassesInPublicNamespaceArePublic(Type type)
    {
		type.IsPublic.ShouldBeTrue();
    }


    public static IEnumerable<object[]> PublicClassDataGenerator() => typeof(AxisOptions).Assembly.GetTypes()
        .Where(t => t.Namespace != null && t.Namespace.Contains(PublicNamespaceFragment) && t.GetCustomAttribute<CompilerGeneratedAttribute>() is null)
        .Select(t => new object[] {t});
}