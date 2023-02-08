using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

namespace PgfPlotsSdk.Internal.Exceptions;

internal class HistogramBinOverlapException<T>: Exception where T : INumber<T>
{
	public HistogramBin<T> OffendingBin { get; }

	public HistogramBinOverlapException(HistogramBin<T> bin) : base("Attempting to add bin that overlaps with an existing bin")
	{
		OffendingBin = bin;
	}
}