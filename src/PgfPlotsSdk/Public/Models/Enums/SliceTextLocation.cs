using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

public enum SliceTextLocation
{
	[PgfPlotsKey("pin")]
	Pin,
	
	[PgfPlotsKey("inside")]
	Inside,
	
	[PgfPlotsKey("legend")]
	Legend
}