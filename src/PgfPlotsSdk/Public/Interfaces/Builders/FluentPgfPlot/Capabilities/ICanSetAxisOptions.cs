using PgfPlotsSdk.Public.ElementDefinitions.Enums;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetAxisOptions<TNextState>
{
	public TNextState SetXLabel(string? label);
	public TNextState SetYLabel(string? label);
	public TNextState SetXMin(float? xMin);
	public TNextState SetYMin(float? yMin);
	public TNextState SetXMax(float? xMax);
	public TNextState SetYMax(float? yMax);
	public TNextState SetMinorXTickNumber(int? tickNum);
	public TNextState SetMinorYTickNumber(int? tickNum);
	public TNextState SetMajorXTickNumber(int? tickNum);
	public TNextState SetMajorYTickNumber(int? tickNum);
	public TNextState SetXTicks(List<float>? ticks);
	public TNextState SetYTicks(List<float>? ticks);
	public TNextState SetGrid(GridSetting? grid);
}