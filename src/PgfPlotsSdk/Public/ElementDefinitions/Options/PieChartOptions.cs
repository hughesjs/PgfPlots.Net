using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Misc;

namespace PgfPlotsSdk.Public.ElementDefinitions.Options;

public record PieChartOptions: OptionsDefinition
{
	[PgfPlotsValueOnly]
	public PieType? PieChartType { get; init; }
	
	[PgfPlotsKey("pos")]
	public LatexPosition? CentrePosition { get; init; }
	
	[PgfPlotsKey("rotate")]
	public float? Rotation { get; init; }
	
	[PgfPlotsKey("radius")]
	public float? Radius { get; init; }
	
	//TODO - Test single and multiple
	[PgfPlotsKey("color")]
	public List<LatexColour>? SliceColours { get; init; }
	
	//TODO - Test single and multiple
	[PgfPlotsKey("explode")]
	public List<float>? SliceExplosionFactors { get; init; }
	
	[PgfPlotsKey("sum")]
	public float? ReferenceSum { get; init; }
	
	[PgfPlotsKey("scale font")]
	public bool? ScaleFont { get; init; }
	
	[PgfPlotsKey("hide number")]
	public bool? HideNumber { get; init; }

	[PgfPlotsKey("before number")]
	public string? BeforeNumberText { get; init; }
	
	[PgfPlotsKey("after number")]
	public string? AfterNumberText { get; init; }
	
	[PgfPlotsKey("text")]
	public PieTextOption? TextPosition { get; init; }

	
}