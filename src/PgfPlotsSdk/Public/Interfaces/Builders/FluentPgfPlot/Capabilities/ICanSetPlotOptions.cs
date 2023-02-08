using PgfPlotsSdk.Public.Models.Enums;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetPlotOptions<TNextState>
{
	public TNextState SetColour(LatexColour? colour);
	public TNextState SetMark(PlotMark? mark);
	public TNextState SetMarkSize(float? size);
	public TNextState SetLineWidth(float? width);
	public TNextState SetFillOpacity(float? opacity);
	public TNextState SetLineStyle(LineStyle? style);
	public TNextState SetBarType(BarType? type);
	public TNextState SetBarWidth(float? width);
	public TNextState SetFillColour(LatexColour? fillColour);
	public TNextState SetSmooth(bool? smooth);
	public TNextState SetOnlyMarks(bool? onlyMarks);
}