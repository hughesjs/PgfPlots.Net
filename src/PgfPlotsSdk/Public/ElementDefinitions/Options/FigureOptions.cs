using PgfPlotsSdk.Public.ElementDefinitions.Enums;

namespace PgfPlotsSdk.Public.ElementDefinitions.Options;

public record FigureOptions: OptionsDefinition
{
	public PositionFlags? Position { get; set; }
}