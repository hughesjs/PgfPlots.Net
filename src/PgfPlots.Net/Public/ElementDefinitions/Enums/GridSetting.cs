using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Public.ElementDefinitions.Enums;

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