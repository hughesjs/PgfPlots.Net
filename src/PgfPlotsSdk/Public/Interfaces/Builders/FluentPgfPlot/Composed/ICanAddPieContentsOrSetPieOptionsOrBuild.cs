using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddPieContentsOrSetPieOptionsOrBuild :
	ICanAddPieContents<ICanAddPieContentsOrSetPieOptionsOrBuild>,
	ICanSetPieOptions<ICanAddPieContentsOrSetPieOptionsOrBuild>, ICanBuild { }