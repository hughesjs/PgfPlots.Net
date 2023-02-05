using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum PieType
{
	[PgfPlotsKey("polar")]
	Polar,
	
	[PgfPlotsKey("square")]
	Square,
	
	[PgfPlotsKey("cloud")]
	Cloud
}