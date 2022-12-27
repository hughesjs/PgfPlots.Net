using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Public.ElementDefinitions.Enums;

public enum PlotMark
{
    [PgfPlotsKey("*")]
    Star,

    [PgfPlotsKey("+")]
    Plus,

    [PgfPlotsKey("x")]
    Cross,

    [PgfPlotsKey("o")]
    Circle,

    [PgfPlotsKey("square")]
    Square,

    [PgfPlotsKey("triangle")]
    Triangle,

    [PgfPlotsKey("diamond")]
    Diamond,

    [PgfPlotsKey("pentagon")]
    Pentagon
}