using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum BarType
{
    [PgfPlotsKey("xbar")]
    XBar,
    
    [PgfPlotsKey("ybar")]
    YBar
}