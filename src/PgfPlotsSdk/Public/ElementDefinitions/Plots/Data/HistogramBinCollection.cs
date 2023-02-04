using System.Collections;
using System.Numerics;
using System.Text;
using PgfPlotsSdk.Internal.Exceptions;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

public class HistogramBinCollection<T>: PlotData, ICollection<HistogramBin<T>> where T : INumber<T>
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
	
	public void Add(HistogramBin<T> newBin)
	{
		if (_bins.Any(bin => BinsCollide(bin, newBin)))
		{
			throw new HistogramBinOverlapException<T>(newBin);
		}
		_bins.Add(newBin);
	}

	public IEnumerator<HistogramBin<T>> GetEnumerator() => _bins.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public void Clear() => _bins.Clear();
	public bool Contains(HistogramBin<T> bin) => _bins.Contains(bin);
	public void CopyTo(HistogramBin<T>[] array, int arrayIndex) => _bins.CopyTo(array, arrayIndex);
	public bool Remove(HistogramBin<T> bin) => _bins.Remove(bin);
	public int Count => _bins.Count;
	
	public bool IsReadOnly => false;
	
	private static bool BinsCollide(HistogramBin<T> bin, HistogramBin<T> newBin) 
		=> newBin.Ceiling >= bin.Floor && newBin.Ceiling < bin.Ceiling || newBin.Floor >= bin.Floor && newBin.Floor < bin.Ceiling;
}