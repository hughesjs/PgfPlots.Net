using System.Reflection;
using PgfPlots.Net.Attributes;

namespace PgfPlots.Net.Services;

internal class PgfPlotsKeyService
{
    public string? GetPgfPlotsKey<T>(string fieldName) =>
        typeof(T).GetProperty(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName;
}