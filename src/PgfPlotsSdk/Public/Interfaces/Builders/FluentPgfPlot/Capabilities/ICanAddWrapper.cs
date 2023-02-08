using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddWrapper<TAxisNextState, TPieNextState>
{
	public ICanAddAxisContents<TAxisNextState> AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options = null);
	public ICanAddPieContents<TPieNextState> AddPgfPlot();
}