using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Misc;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetPieOptions
{
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetPieChartType(PieType? type);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetCentrePosition(LatexPosition? position);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetRotation(float? rotation);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetRadius(float? radius);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetSliceColours(List<LatexColour>? sliceColours);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetSliceExplosionFactors(List<float>? explosionFactors);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetReferenceSum(float? sum);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetScaleFont(bool? enabled);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetHideNumber(bool? enabled);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetBeforeNumberText(string beforeText);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetAfterNumberText(string? afterText);
	public ICanAddPieContentsOrSetPieOptionsOrBuild SetTextPosition(PieTextOption? textPosition);
}