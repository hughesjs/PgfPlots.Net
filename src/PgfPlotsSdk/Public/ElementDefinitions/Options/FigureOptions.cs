using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;

namespace PgfPlotsSdk.Public.ElementDefinitions.Options;

public record FigureOptions: OptionsDefinition
{
	[PgfPlotsValueOnly]
	[PgfPlotsFlagSeparator("")]
	public PositionFlags? Position { get; set; }
}