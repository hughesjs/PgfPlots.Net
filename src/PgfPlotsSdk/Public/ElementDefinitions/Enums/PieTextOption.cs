using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum PieTextOption
{
	[PgfPlotsKey("pin")]
	Pin,
		
	[PgfPlotsKey("inside")]
	Inside,
	
	[PgfPlotsKey("legend")]
	Legend
}