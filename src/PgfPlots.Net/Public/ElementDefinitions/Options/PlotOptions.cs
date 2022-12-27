using PgfPlots.Net.Internal.Attributes;
using PgfPlots.Net.Public.ElementDefinitions.Enums;

namespace PgfPlots.Net.Public.ElementDefinitions.Options;

public record PlotOptions: OptionsDefinition
{
    [PgfPlotsKey("color")]
    public LatexColour? Colour { get; init; }

    [PgfPlotsKey("mark")]
    public PlotMark? Mark { get; init; }

    [PgfPlotsKey("mark size")]
    public float? MarkSize { get; init; }
    
    [PgfPlotsKey("line width")]
    public float? LineWidth { get; init; }

    [PgfPlotsKey("fill opacity")] 
    public float? FillOpacity { get; init; }
    
    [PgfPlotsValueOnly]
    public LineStyle? LineStyle { get; init; }
    
    [PgfPlotsValueOnly]
    public BarType? BarType { get; init; }
    
    [PgfPlotsKey("fill")]
    public LatexColour? Fill { get; init; }
    
    [PgfPlotsKey("smooth")]
    public bool? Smooth { get; init; }
    
    [PgfPlotsKey("only marks")]
    public bool? OnlyMarks { get; init; }

    //TODO - Add custom keys dict
    
    //TODO - Add mark options
}