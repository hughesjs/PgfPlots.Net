using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

public enum AxisType
{
    [PgfPlotsKey("axis")]
    Standard,
    
    [PgfPlotsKey("semilogxaxis")]
    SemiLogX,
    
    [PgfPlotsKey("semilogyaxis")]
    SemiLogY,
    
    [PgfPlotsKey("loglogaxis")]
    LogLog
}