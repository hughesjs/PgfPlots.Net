using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Misc;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetPieOptions<TNextState>
{
	public TNextState SetPieChartType(PieType? type);
	public TNextState SetCentrePosition(float x, float y);
	public TNextState SetRotation(float? rotation);
	public TNextState SetRadius(float? radius);
	public TNextState SetSliceColours(params LatexColour[] sliceColours);
	public TNextState SetSliceExplosionFactors(params float[] explosionFactors);
	public TNextState SetReferenceSum(float? sum);
	public TNextState SetScaleFont(bool? enabled);
	public TNextState SetHideNumber(bool? enabled);
	public TNextState SetBeforeNumberText(string beforeText);
	public TNextState SetAfterNumberText(string? afterText);
	public TNextState SetTextPosition(PieTextOption? textPosition);
}