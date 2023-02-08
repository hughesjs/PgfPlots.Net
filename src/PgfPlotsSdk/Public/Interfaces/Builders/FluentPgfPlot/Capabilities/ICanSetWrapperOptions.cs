using PgfPlotsSdk.Public.Models.Enums;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetWrapperOptions<TNextState>
{
	public TNextState SetPlacementFlag(PositionFlags flagsToSet);
}