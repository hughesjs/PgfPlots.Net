using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

public interface ICanSetWrapperOptions
{
	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetPlacementFlag(PositionFlags flagsToSet);
}