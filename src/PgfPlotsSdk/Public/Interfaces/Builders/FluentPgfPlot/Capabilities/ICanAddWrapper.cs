using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddWrapper<TAxisNextState, TPieNextState>
{
	public TAxisNextState AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options = null);
	public TPieNextState AddPgfPlot();
}