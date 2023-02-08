using System.Numerics;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

public class PieChartSliceData<T>: ILatexData where T: INumber<T>
{
	public T Value { get; }
	public string Label { get; }
	
	public PieChartSliceData(T value, string label = "")
	{
		Value = value;
		Label = label;
	}

	public string GetDataLatexString()
	{
		if (string.IsNullOrEmpty(Label))
		{
			return Value.ToString() ?? throw new("Stringified slice data cannot be null");
		}

		return $"{Value.ToString()}/{{{Label}}}";
	}
}