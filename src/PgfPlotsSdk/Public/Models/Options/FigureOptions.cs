using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Public.Models.Enums;

namespace PgfPlotsSdk.Public.Models.Options;

public record FigureOptions: OptionsDefinition
{
	[PgfPlotsValueOnly]
	[PgfPlotsFlagSeparator("")]
	public PositionFlags? Position { get; set; }
}