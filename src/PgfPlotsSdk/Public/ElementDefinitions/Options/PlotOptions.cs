using PgfPlotsSdk.Internal.Attributes;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;

namespace PgfPlotsSdk.Public.ElementDefinitions.Options;

public record PlotOptions: OptionsDefinition
{
    [PgfPlotsKey("color")]
    public LatexColour? Colour { get; set; }

    [PgfPlotsKey("mark")]
    public PlotMark? Mark { get; set; }

    [PgfPlotsKey("mark size")]
    public float? MarkSize { get; set; }
    
    [PgfPlotsKey("line width")]
    public float? LineWidth { get; set; }

    [PgfPlotsKey("fill opacity")] 
    public float? FillOpacity { get; set; }
    
    [PgfPlotsValueOnly]
    public LineStyle? LineStyle { get; set; }
    
    [PgfPlotsValueOnly]
    public BarType? BarType { get; set; }
    
    [PgfPlotsKey("bar width")]
    public float? BarWidth { get; set; }
    
    [PgfPlotsKey("fill")]
    public LatexColour? FillColour { get; set; }
    
    [PgfPlotsKey("smooth")]
    public bool? Smooth { get; set; }
    
    [PgfPlotsKey("only marks")]
    public bool? OnlyMarks { get; set; }

    //TODO - Add custom keys dict
    
    //TODO - Add mark options
}