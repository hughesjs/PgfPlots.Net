using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Public.ElementDefinitions.Enums;

public enum LatexColour
{
    [PgfPlotsKey("red")]
    Red,
    
    [PgfPlotsKey("green")]
    Green,
    
    [PgfPlotsKey("blue")]
    Blue,
    
    [PgfPlotsKey("cyan")]
    Cyan,
    
    [PgfPlotsKey("magenta")]
    Magenta,
    
    [PgfPlotsKey("yellow")]
    Yellow,
    
    [PgfPlotsKey("black")]
    Black,
    
    [PgfPlotsKey("white")]
    White,
    
    [PgfPlotsKey("hsb")]
    Hsb,
    
    [PgfPlotsKey("rgb")]
    Rgb
}