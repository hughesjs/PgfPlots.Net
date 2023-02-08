using System.Collections;
using System.Reflection;
using System.Text;
using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Internal.Reflection;

namespace PgfPlotsSdk.Public.ElementDefinitions.Options;

public abstract record OptionsDefinition
{
	public virtual Dictionary<string, string?> GetOptionsDictionary()
	{
		//TODO - Refactor into strategy or something
		Dictionary<string, string?> propsDict = new();
		foreach (PropertyInfo prop in GetType().GetProperties())
		{
			MethodInfo? getter = prop.GetGetMethod();
			object? value = getter?.Invoke(this, null);
			if (value is null) continue;

			Type currentType = GetType();
			Type dataType = value.GetType();

			string optionName = PgfPlotsAttributeHelper.GetPgfPlotsKey(currentType, prop.Name)
			                    ?? prop.Name;

			if (PgfPlotsAttributeHelper.IsValueOnlyField(currentType, prop.Name))
			{
				string valuePgfPlotKey;
				if (dataType.IsEnum && dataType.GetCustomAttribute<FlagsAttribute>() is not null)
				{
					valuePgfPlotKey = JoinFlags(dataType, (Enum)value);
				}
				else
				{
					valuePgfPlotKey = PgfPlotsAttributeHelper.GetPgfPlotsKey(dataType, value.ToString()!) ??
					                  value.ToString()!;
				}

				propsDict.Add(valuePgfPlotKey, null);
				continue;
			}

			if (value is bool)
			{
				if (value is true)
				{
					propsDict.Add(optionName, null);
				}

				continue;
			}

			if (dataType.IsEnum)
			{
				if (dataType.GetCustomAttribute<FlagsAttribute>() is null)
				{
					string? valuePgfPlotKey = PgfPlotsAttributeHelper.GetPgfPlotsKey(dataType, value.ToString()!);
					propsDict.Add(optionName, valuePgfPlotKey);
					continue;
				}

				string flagsValue = JoinFlags(dataType, (Enum)value);

				string key = PgfPlotsAttributeHelper.GetPgfPlotsKey(dataType, prop.Name) ?? prop.Name;
				propsDict.Add(key, flagsValue);

				continue;
			}

			if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
			{
				Type innerType = dataType.GetGenericArguments().First();
				if (innerType.IsEnum)
				{
					string csv = string.Join(',', ((ICollection)value)
						.OfType<object>()
						.Select(v =>
							PgfPlotsAttributeHelper.GetPgfPlotsKey(dataType.GetGenericArguments()[0], v.ToString()!)));

					propsDict.Add(optionName, $"{{{csv}}}");
					continue;
				}

				propsDict.Add(optionName, $"{{{string.Join(',', ((ICollection)value).OfType<object>())}}}");
				continue;
			}

			propsDict.Add(optionName, value.ToString());
		}

		return propsDict;
	}

	private string JoinFlags(Type dataType, Enum value)
	{
		StringBuilder builder = new();
		string separator = dataType.GetCustomAttribute<PgfPlotsFlagSeparatorAttribute>()?.Separator ??
		                   string.Empty;
		foreach (var en in Enum.GetValues(dataType))
		{
			if (value.HasFlag((Enum)en))
			{
				string? valuePgfPlotKey = PgfPlotsAttributeHelper.GetPgfPlotsKey(dataType, en.ToString()!);
				builder.Append($"{valuePgfPlotKey}{separator}");
			}
		}

		return builder.ToString();
	}
}