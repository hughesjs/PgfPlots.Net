using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddRoot
{
	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions AddFigure(FigureOptions? figureOptions = null);
}
