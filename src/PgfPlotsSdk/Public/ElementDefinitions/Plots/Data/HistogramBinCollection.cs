using System.Numerics;
using PgfPlotsSdk.Internal.Exceptions;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

public class HistogramBinCollection<T>: PlotData where T : INumber<T>
{
	private readonly List<HistogramBin<T>> _bins;
	
	public HistogramBinCollection()
	{
		_bins = new();
	}
	
	public override string GetDataLatexString()
	{
		string baseIntervals = string.Join(" ", _bins.Select(b => b.GetDataLatexString()));
		return $"{baseIntervals} ({_bins.Max(b => b.Ceiling)},0)";
	}
	
	public void AddBin(HistogramBin<T> newBin)
	{
		if (_bins.Any(bin => BinsCollide(bin, newBin)))
		{
			throw new HistogramBinOverlapException<T>(newBin);
		}
		_bins.Add(newBin);
	}

	public void AddValueToBin(T value)
	{
		_ = _bins.Any(bin => bin.TryAddToBin(value));
	}
	
	public int Count => _bins.Count;
	
	public bool IsReadOnly => false;
	
	private static bool BinsCollide(HistogramBin<T> bin, HistogramBin<T> newBin) 
		=> (newBin.Ceiling >= bin.Floor && newBin.Ceiling < bin.Ceiling) || (newBin.Floor >= bin.Floor && newBin.Floor < bin.Ceiling);
}