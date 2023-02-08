using PgfPlotsSdk.Internal.Services;
using PgfPlotsSdk.Public.ElementDefinitions;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;
using PgfPlotsSdk.Public.Exceptions;
using PgfPlotsSdk.Public.Interfaces.Services;
using Shouldly;

namespace PgfPlotsSdk.Tests.Services;

public class PgfPlotSourceGeneratorTests
{
	private readonly IPgfPlotSourceGenerator _sourceGenerator = new PgfPlotSourceGenerator();
	
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
		FigureDefinition definition = new()
		{
			Caption = "Cap",
			Label = "Lab",
			Plots = new()
		};
		
		string res = _sourceGenerator.GenerateSourceCode(definition);
		res.ShouldNotBeNullOrEmpty();
	}

	[Fact]
	public void ThrowsPgfPlotGenerationExceptionWithInvalidDefinition()
	{
		PgfPlotWithAxesDefinition definition = new(null!, new());
		PgfPlotsGeneratorException ex = Should.Throw<PgfPlotsGeneratorException>(() => _sourceGenerator.GenerateSourceCode(definition));
		ex.InnerException.ShouldNotBeNull();
	}
}