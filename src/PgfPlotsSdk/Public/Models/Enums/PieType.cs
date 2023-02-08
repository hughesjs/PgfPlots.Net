using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

public enum PieType
{
	[PgfPlotsKey("polar")]
	Polar,
	
	[PgfPlotsKey("square")]
	Square,
	
	[PgfPlotsKey("cloud")]
	Cloud
}