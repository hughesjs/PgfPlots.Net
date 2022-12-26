using System.Reflection;
using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Internal.Reflection;

internal static class PgfPlotsKeyHelper
{
    public static string? GetPgfPlotsKey<T>(string fieldName) =>
        typeof(T).GetProperty(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName;
    
    
}