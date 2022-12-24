namespace PgfPlots.Net;

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