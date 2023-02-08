using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddFigureDecorations
{
	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetLabel(string label);
	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetCaption(string caption);
}