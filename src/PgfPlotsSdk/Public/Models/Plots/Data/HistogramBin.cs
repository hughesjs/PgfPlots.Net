using System.Numerics;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.Models.Plots.Data;

public class HistogramBin<T> : ILatexData where T: INumber<T>
{
	public HistogramBin(T floor, T ceiling)
	{
		Floor = floor;
		Ceiling = ceiling;
	}
	public T Floor { get; }
	public T Ceiling { get; }

	public bool TryAddToBin(T num)
	{
		if (!IsInBin(num))
		{
			return false;
		}

		Frequency++;
		return true;
	}

	public int Frequency { get; private set; }

	public bool IsInBin(T num)  => Floor <= num && num < Ceiling;
	
	public string GetDataLatexString() => $"({Floor},{Frequency})";
}