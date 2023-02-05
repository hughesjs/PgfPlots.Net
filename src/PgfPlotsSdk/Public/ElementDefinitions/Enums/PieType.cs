using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum PieType
{
	[PgfPlotsKey("standard")] // This is an unknown key and should just be ignored...
	Standard,
	
	[PgfPlotsKey("polar")]
	Polar,
	
	[PgfPlotsKey("square")]
	Square,
	
	[PgfPlotsKey("cloud")]
	Cloud
}