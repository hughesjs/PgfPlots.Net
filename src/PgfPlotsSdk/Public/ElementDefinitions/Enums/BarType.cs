using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum BarType
{
    [PgfPlotsKey("xbar")]
    XBar,
    
    [PgfPlotsKey("xbar interval")]
    XBarInterval,
    
    [PgfPlotsKey("ybar")]
    YBar,
    
    [PgfPlotsKey("ybar interval")]
    YBarInterval,
}