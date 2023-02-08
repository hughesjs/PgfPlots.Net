using PgfPlotsSdk.Public.Models.Enums;

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
	public TNextState SetXTicks(params float[] ticks);
	public TNextState SetYTicks(params float[] ticks);
	public TNextState SetGrid(GridSetting? grid);
}