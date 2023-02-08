using PgfPlotsSdk.Public.Models.Options;

namespace PgfPlotsSdk.Internal.ElementDefinitions;

internal class FigureDefinition
{
	public string? Label { get; }
	public string? Caption { get; }
	
	public FigureOptions Options { get; }
	
	public List<PgfPlotDefinition>? Plots { get; }

	public FigureDefinition(FigureOptions options, string? label = null, string? caption = null, params PgfPlotDefinition[] plots)
	{
		Options = options;
		Label = label;
		Caption = caption;
		Plots = plots.ToList();
	}
}