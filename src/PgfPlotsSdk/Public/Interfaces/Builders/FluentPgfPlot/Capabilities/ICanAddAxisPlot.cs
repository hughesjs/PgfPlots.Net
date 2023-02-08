using PgfPlotsSdk.Public.Interfaces.Data;
using PgfPlotsSdk.Public.Models.Options;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddAxisPlot<TNextState>
{
	TNextState AddPlot(IEnumerable<ILatexData> data, PlotOptions? options = null);
}