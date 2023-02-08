using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

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