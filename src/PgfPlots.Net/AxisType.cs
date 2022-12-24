namespace PgfPlots.Net;

public enum AxisType
{
    [PgfPlotsKey("axis")]
    Standard,
    
    [PgfPlotsKey("semilogaxis")]
    SemiLog,
    
    [PgfPlotsKey("loglogaxis")]
    LogLog
}