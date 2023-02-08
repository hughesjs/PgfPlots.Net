namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddFigureDecorations<TNextState>
{
	public TNextState SetLabel(string label);
	public TNextState SetCaption(string caption);
}