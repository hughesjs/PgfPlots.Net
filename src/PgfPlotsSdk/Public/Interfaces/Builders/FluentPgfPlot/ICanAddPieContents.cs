using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot;

public interface ICanAddPieContents: ICanBuild
{
	ICanAddPieContents AddPie<T>(IEnumerable<PieChartSliceData<T>> slices, PieChartOptions? options = null) where T : INumber<T>;
}