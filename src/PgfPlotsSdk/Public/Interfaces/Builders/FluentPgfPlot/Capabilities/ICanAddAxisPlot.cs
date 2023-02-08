using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddAxisPlot<TNextState>
{
	TNextState AddPlot(IEnumerable<ILatexData> data, PlotOptions? options = null);
}