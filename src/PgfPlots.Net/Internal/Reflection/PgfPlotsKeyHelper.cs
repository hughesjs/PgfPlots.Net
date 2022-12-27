using System.Reflection;
using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Internal.Reflection;

internal static class PgfPlotsKeyHelper
{
    public static string? GetPgfPlotsKey<T>(string fieldName) => GetPgfPlotsKey(typeof(T), fieldName);
    public static string? GetPgfPlotsKey(Type type, string fieldName) =>
        type.GetProperty(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName
        ?? type.GetField(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName;

    
}