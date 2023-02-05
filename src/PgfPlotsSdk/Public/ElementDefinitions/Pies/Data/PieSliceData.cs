using System.Numerics;

namespace PgfPlotsSdk.Public.ElementDefinitions.Pies.Data;

public class PieSliceData<T> where T: INumber<T>
{
	public T Value { get; }
	public string Label { get; }
	
	public PieSliceData(T value, string label)
	{
		Value = value;
		Label = label;
	}
}