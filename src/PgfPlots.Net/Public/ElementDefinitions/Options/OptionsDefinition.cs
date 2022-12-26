using System.Collections;
using System.Reflection;
using PgfPlots.Net.Internal.Reflection;

namespace PgfPlots.Net.Public.ElementDefinitions.Options;

public abstract record OptionsDefinition
{
    public virtual Dictionary<string, string?> GetOptionsDictionary()
    {
        Dictionary<string, string?> propsDict = new();
        foreach (PropertyInfo prop in GetType().GetProperties())
        {
            string optionName = PgfPlotsKeyHelper.GetPgfPlotsKey<AxisDefinition>(prop.Name)
                                ?? prop.Name;

            MethodInfo? getter = prop.GetGetMethod();
            object? value = getter?.Invoke(this, null);
            if (value is null) continue;

            Type dataType = value.GetType();


            if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
            {
                propsDict.Add(optionName, $"{{{string.Join(',', ((ICollection)value).OfType<object>())}}}");
                continue;
            }

            propsDict.Add(optionName, value.ToString());
        }

        return propsDict;
    }
}