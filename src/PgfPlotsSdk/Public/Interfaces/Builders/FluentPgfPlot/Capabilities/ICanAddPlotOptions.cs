using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanAddPlotOptions
{
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetColour(LatexColour? colour);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMark(PlotMark? mark);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMarkSize(float? size);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetLineWidth(float? width);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetFillOpacity(float? opacity);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetLineStyle(LineStyle? style);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetBarType(BarType? type);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetBarWidth(float? width);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetFill(LatexColour? fillColour);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetSmooth(bool? smooth);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetOnlyMarks(bool? onlyMarks);
}