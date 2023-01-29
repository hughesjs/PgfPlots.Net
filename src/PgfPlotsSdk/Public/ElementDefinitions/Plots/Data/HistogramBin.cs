using System.Numerics;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

public class HistogramBin<T> : PlotData where T: INumber<T>
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

	public float Centre => ((float)(object)(Ceiling - Floor) / 2f) + (float)(object)Floor;
	public override string GetDataLatexString() => $"({Centre},{Frequency})";
}