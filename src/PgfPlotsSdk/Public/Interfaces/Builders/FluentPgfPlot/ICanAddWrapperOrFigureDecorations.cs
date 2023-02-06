namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot;

public interface ICanAddWrapperOrFigureDecorations: ICanAddWrapper
{
	public ICanAddWrapperOrFigureDecorations SetLabel(string label);
	public ICanAddWrapperOrFigureDecorations SetCaption(string caption);
}