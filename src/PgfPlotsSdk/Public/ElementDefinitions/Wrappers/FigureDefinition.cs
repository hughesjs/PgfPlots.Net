using PgfPlotsSdk.Public.ElementDefinitions.Options;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class FigureDefinition
{
	public string? Label { get; init; }
	public string? Caption { get; init; }
	
	public FigureOptions Options { get; init; }
	
	public List<PgfPlotDefinition>? Plots { get; init;  }

	public FigureDefinition(FigureOptions options, string? label = null, string? caption = null, params PgfPlotDefinition[] plots)
	{
		Options = options;
		Label = label;
		Caption = caption;
		Plots = plots.ToList();
	}
}