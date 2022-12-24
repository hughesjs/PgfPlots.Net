using PgfPlots.Net.Attributes;

namespace PgfPlots.Net.ElementDefinitions.Enums;

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