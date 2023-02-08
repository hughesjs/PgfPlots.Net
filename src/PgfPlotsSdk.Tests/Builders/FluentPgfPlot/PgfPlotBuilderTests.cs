using PgfPlotsSdk.Public.Builders.FluentPgfPlot;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot;
using PgfPlotsSdk.Public.Interfaces.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.Builders.FluentPgfPlot;

public class PgfPlotBuilderTests
{
	private readonly ICanCreateRoot _root;
	
	private static readonly ILatexData[] Data1 = {
		new Cartesian2<int>(0,1),
		new Cartesian2<int>(2,3),
		new Cartesian2<int>(4,5)
	};
	public PgfPlotBuilderTests()
	{
		_root = PgfPlotBuilder.CreateBuilder();
	}
	
	[Fact]
	public void BuilderIsCreated()
	{
		_root.ShouldNotBeNull();
	}
	
	[Fact]
	public void CanCreateBasicPlot()
	{

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();
		;
	}
}