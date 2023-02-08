using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum SliceTextLocation
{
	[PgfPlotsKey("pin")]
	Pin,
	
	[PgfPlotsKey("inside")]
	Inside,
	
	[PgfPlotsKey("legend")]
	Legend
}