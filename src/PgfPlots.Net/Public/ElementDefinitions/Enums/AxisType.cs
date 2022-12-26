using PgfPlots.Net.Internal.Attributes;

namespace PgfPlots.Net.Public.ElementDefinitions.Enums;

public enum AxisType
{
    [PgfPlotsKey("axis")]
    Standard,
    
    [PgfPlotsKey("semilogaxis")]
    SemiLog,
    
    [PgfPlotsKey("loglogaxis")]
    LogLog
}