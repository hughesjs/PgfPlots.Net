using PgfPlotsSdk.Public.ElementDefinitions.Options;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddRoot<TNextState>
{
	public TNextState AddFigure(FigureOptions? figureOptions = null);
}
