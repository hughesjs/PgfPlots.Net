using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Public.ElementDefinitions.Enums;

public enum BarType
{
    [PgfPlotsKey("xbar")]
    XBar,
    
    [PgfPlotsKey("ybar")]
    YBar
}