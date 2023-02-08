using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot;

public interface ICanAddAxisContents: ICanBuild
{
	ICanAddAxisContents AddPlot(IEnumerable<ILatexData> data, PlotOptions? options = null);
}