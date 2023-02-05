using System.Numerics;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Pies.Data;

public class PieSliceData<T>: ILatexData where T: INumber<T>
{
	public T Value { get; }
	public string Label { get; }
	
	public PieSliceData(T value, string label = "")
	{
		Value = value;
		Label = label;
	}

	public string GetDataLatexString()
	{
		throw new NotImplementedException();
	}
}