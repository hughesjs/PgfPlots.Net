using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddAxisPlotOrSetPlotOptionsOrBuild :
	ICanAddAxisPlot<ICanAddAxisPlotOrSetPlotOptionsOrBuild>,
	ICanSetPlotOptions<ICanAddAxisPlotOrSetPlotOptionsOrBuild>,
	ICanBuild { }