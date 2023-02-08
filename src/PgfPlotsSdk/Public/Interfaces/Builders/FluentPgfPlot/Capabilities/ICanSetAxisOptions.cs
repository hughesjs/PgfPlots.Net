using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetAxisOptions
{
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXLabel(string? label);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYLabel(string? label);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXMin(float? xMin);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYMin(float? yMin);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXMax(float? xMax);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYMax(float? yMax);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMinorXTickNumber(int? tickNum);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMinorYTickNumber(int? tickNum);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMajorXTickNumber(int? tickNum);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMajorYTickNumber(int? tickNum);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXTicks(List<float>? ticks);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYTicks(List<float>? ticks);
	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetGrid(GridSetting? grid);
}