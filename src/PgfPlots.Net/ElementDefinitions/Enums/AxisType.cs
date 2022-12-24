using PgfPlots.Net.Attributes;

namespace PgfPlots.Net.ElementDefinitions.Enums;

public enum AxisType
{
    [PgfPlotsKey("axis")]
    Standard,
    
    [PgfPlotsKey("semilogaxis")]
    SemiLog,
    
    [PgfPlotsKey("loglogaxis")]
    LogLog
}