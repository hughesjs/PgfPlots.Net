using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Public.Models.Enums;

namespace PgfPlotsSdk.Public.Models.Options;

public record AxisOptions: OptionsDefinition
{
	[PgfPlotsKey("xlabel")]
	public string? XLabel { get; set; }
	
	[PgfPlotsKey("ylabel")]
	public string? YLabel { get; set; }
	
	[PgfPlotsKey("xmin")]
	public float?  XMin   { get; set; }
	
	[PgfPlotsKey("ymin")]
	public float?  YMin   { get; set; }
	
	[PgfPlotsKey("xmax")]
	public float?  XMax   { get; set; }
	
	[PgfPlotsKey("ymax")]
	public float?  YMax   { get; set; }
	
	[PgfPlotsKey("minor y tick num")]
	public int? MinorYTickNumber { get; set; }
	
	[PgfPlotsKey("minor x tick num")]
	public int? MinorXTickNumber { get; set; }

	[PgfPlotsKey("xtick")]
	public List<float>? XTicks { get; set; }
	
	[PgfPlotsKey("ytick")]
	public List<float>? YTicks { get; set; }

	[PgfPlotsKey("grid")]
	public GridSetting? Grid { get; set; }
	
	//TODO - Add custom keys dict
	
	//TODO - Grid options
}
