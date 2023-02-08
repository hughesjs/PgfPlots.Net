using System.Numerics;
using PgfPlotsSdk.Public.Models.Options;
using PgfPlotsSdk.Public.Models.Plots.Data;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddPieContents<TNextState>
{
	TNextState AddPie<T>(IEnumerable<PieChartSliceData<T>> slices, PieChartOptions? options = null) where T : INumber<T>;
}