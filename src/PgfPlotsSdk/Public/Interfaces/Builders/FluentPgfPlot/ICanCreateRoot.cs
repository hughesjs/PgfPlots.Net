using PgfPlotsSdk.Public.ElementDefinitions.Options;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot;

public interface ICanCreateRoot : ICanAddWrapper
{
	public ICanAddWrapperOrFigureDecorations AddFigure(FigureOptions? figureOptions = null);
}
