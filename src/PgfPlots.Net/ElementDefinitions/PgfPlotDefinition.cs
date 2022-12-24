namespace PgfPlots.Net.ElementDefinitions;

public record PgfPlotDefinition
{
    public required AxisDefinition AxisDefinition { get; init; }
}