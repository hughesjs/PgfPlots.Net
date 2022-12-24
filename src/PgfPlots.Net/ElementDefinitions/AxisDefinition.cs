using PgfPlots.Net.Attributes;
using PgfPlots.Net.ElementDefinitions.Enums;

namespace PgfPlots.Net.ElementDefinitions;

public record AxisDefinition
{
	[PgfPlotsKey("xlabel")]
	public string? XLabel { get; init; }
	
	[PgfPlotsKey("ylabel")]
	public string? YLabel { get; init; }
	
	[PgfPlotsKey("xmin")]
	public float?  XMin   { get; init; }
	
	[PgfPlotsKey("ymin")]
	public float?  YMin   { get; init; }
	
	[PgfPlotsKey("xmax")]
	public float?  XMax   { get; init; }
	
	[PgfPlotsKey("ymax")]
	public float?  YMax   { get; init; }
	
	[PgfPlotsKey("minor y tick no")]
	public int? MinorYTickNumber { get; init; }
	
	[PgfPlotsKey("minor x tick no")]
	public int? MinorXTickNumber { get; init; }
	
	[PgfPlotsKey("xticks")]
	public List<float> XTicks { get; init; } = new();
	
	[PgfPlotsKey("yticks")]
	public List<float> YTicks { get; init; } = new();

	[PgfPlotsKey("grid")]
	public GridSetting Grid { get; init; } = new();
	
	//TODO - Grid style
}
