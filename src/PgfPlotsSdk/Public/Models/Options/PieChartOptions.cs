using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Public.Models.Enums;
using PgfPlotsSdk.Public.Models.Misc;

namespace PgfPlotsSdk.Public.Models.Options;

public record PieChartOptions: OptionsDefinition
{
	[PgfPlotsValueOnly]
	public PieType? PieChartType { get; set; }
	
	[PgfPlotsKey("pos")]
	public LatexPosition? CentrePosition { get; set; }
	
	[PgfPlotsKey("rotate")]
	public float? Rotation { get; set; }
	
	[PgfPlotsKey("radius")]
	public float? Radius { get; set; }
	
	//TODO - Test single and multiple
	[PgfPlotsKey("color")]
	public List<LatexColour>? SliceColours { get; set; }
	
	//TODO - Test single and multiple
	[PgfPlotsKey("explode")]
	public List<float>? SliceExplosionFactors { get; set; }
	
	[PgfPlotsKey("sum")]
	public float? ReferenceSum { get; set; }
	
	[PgfPlotsKey("scale font")]
	public bool? ScaleFont { get; set; }
	
	[PgfPlotsKey("hide number")]
	public bool? HideNumber { get; set; }

	[PgfPlotsKey("before number")]
	public string? BeforeNumberText { get; set; }
	
	[PgfPlotsKey("after number")]
	public string? AfterNumberText { get; set; }
	
	[PgfPlotsKey("text")]
	public PieTextOption? TextPosition { get; set; }

	
}