using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum GridSetting
{
    [PgfPlotsKey("major")]
    Major,
    
    [PgfPlotsKey("minor")]
    Minor,
    
    [PgfPlotsKey("both")]
    Both,
    
    [PgfPlotsKey("none")]
    None
}