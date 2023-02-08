using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddAxisContentsOrSetAxisOptionsOrBuild :
	ICanAddAxisContents<ICanAddAxisContentsOrSetAxisOptionsOrBuild>,
	ICanSetAxisOptions<ICanAddAxisContentsOrSetAxisOptionsOrBuild>,
	ICanBuild { }