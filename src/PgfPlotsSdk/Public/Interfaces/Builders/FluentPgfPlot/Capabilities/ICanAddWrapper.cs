using PgfPlotsSdk.Public.Models.Enums;
using PgfPlotsSdk.Public.Models.Options;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddWrapper<TAxisNextState, TPieNextState>
{
	public TAxisNextState AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options = null);
	public TPieNextState AddPgfPlot();
}