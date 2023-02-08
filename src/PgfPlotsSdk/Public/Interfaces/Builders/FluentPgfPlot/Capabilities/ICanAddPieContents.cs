using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddPieContents<TNextState>
{
	TNextState AddPie<T>(IEnumerable<PieChartSliceData<T>> slices, PieChartOptions? options = null) where T : INumber<T>;
}