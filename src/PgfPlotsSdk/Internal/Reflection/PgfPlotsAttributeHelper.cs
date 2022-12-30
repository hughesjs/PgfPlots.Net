using System.Reflection;
using PgfPlotsSdk.Public.ElementDefinitions;
using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Internal.Reflection;

internal static class PgfPlotsAttributeHelper
{
    public static string? GetPgfPlotsKey<T>(string fieldName) => GetPgfPlotsKey(typeof(T), fieldName);
    public static string? GetPgfPlotsKey(Type type, string fieldName) =>
        type.GetProperty(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName
        ?? type.GetField(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName;

    public static bool IsValueOnlyField<T>(string fieldName) => IsValueOnlyField(typeof(T), fieldName);

    public static bool IsValueOnlyField(Type t, string fieldName) =>
        (t.GetProperty(fieldName)?.GetCustomAttribute<PgfPlotsValueOnly>()
         ?? t.GetField(fieldName)?.GetCustomAttribute<PgfPlotsValueOnly>()) is not null;



}