namespace PgfPlots.Net.Public.ElementDefinitions.Wrappers;

public class FigureDefinition
{
	public string? Label { get; init; }
	public string? Caption { get; init; }
	
	public List<PgfPlotDefinition>? Plots { get; init;  }
}