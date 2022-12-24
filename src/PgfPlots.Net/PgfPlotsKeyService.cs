using System.Reflection;

namespace PgfPlots.Net;

internal class PgfPlotsKeyService
{
    public string? GetPgfPlotsKey<T>(string fieldName) =>
        typeof(T).GetProperty(fieldName)?.GetCustomAttribute<PgfPlotsKeyAttribute>()?.KeyName;
}