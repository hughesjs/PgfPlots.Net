using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddWrapperOrAddRoot: 
	ICanAddWrapper<ICanAddAxisPlotOrSetAxisOptions, ICanAddPieContents<ICanAddPieContentsOrSetPieOptionsOrBuild>>,
	ICanAddRoot<ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions> { }