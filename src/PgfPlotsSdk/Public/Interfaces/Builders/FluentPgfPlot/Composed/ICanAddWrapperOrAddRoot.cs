using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddWrapperOrAddRoot: 
	ICanAddWrapper<ICanAddAxisContentsOrSetAxisOptionsOrBuild, ICanAddPieContentsOrSetPieOptionsOrBuild>,
	ICanAddRoot<ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions> { }