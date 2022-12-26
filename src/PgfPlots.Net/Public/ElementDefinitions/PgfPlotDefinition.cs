using PgfPlots.Net.Public.ElementDefinitions.Options;

namespace PgfPlots.Net.Public.ElementDefinitions;

public record PgfPlotDefinition
{
    public required AxisDefinition AxisDefinition { get; init; }
}