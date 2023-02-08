using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

public enum LineStyle
{
    [PgfPlotsKey("solid")]
    Solid,

    [PgfPlotsKey("dashed")]
    Dashed,

    [PgfPlotsKey("dotted")]
    Dotted,

    [PgfPlotsKey("loosely dotted")]
    LooselyDotted,

    [PgfPlotsKey("loosely dashed")]
    LooselyDashed,

    [PgfPlotsKey("densely dotted")]
    DenselyDotted,

    [PgfPlotsKey("densely dashed")]
    DenselyDashed,
}