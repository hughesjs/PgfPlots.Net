using PgfPlotsSdk.Internal.ElementDefinitions;
using PgfPlotsSdk.Internal.Services;
using Shouldly;

namespace PgfPlotsSdk.Tests.Services;

public class PgfPlotSourceGeneratorTests
{
	private readonly PgfPlotSourceGenerator _sourceGenerator = new();
	
	[Fact]
	public void GeneratesSourceWithValidPgfPlotDefinition()
	{
		PgfPlotWithAxesDefinition definition = new(new(), new());
		string res = _sourceGenerator.GenerateSourceCode(definition);
		res.ShouldNotBeNullOrEmpty();
	}
	
	[Fact]
	public void GeneratesSourceWithValidFigureDefinition()
	{
		FigureDefinition definition = new(new(), "Lab", "Cap");
		
		string res = _sourceGenerator.GenerateSourceCode(definition);
		res.ShouldNotBeNullOrEmpty();
	}
}