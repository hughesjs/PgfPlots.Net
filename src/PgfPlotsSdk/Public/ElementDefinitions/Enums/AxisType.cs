using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.ElementDefinitions.Enums;

public enum AxisType
{
    [PgfPlotsKey("axis")]
    Standard,
    
    [PgfPlotsKey("semilogaxis")]
    SemiLog,
    
    [PgfPlotsKey("loglogaxis")]
    LogLog
}