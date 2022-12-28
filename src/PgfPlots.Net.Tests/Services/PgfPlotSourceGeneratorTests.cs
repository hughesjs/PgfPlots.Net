using PgfPlots.Net.Internal.Services;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using PgfPlots.Net.Public.ElementDefinitions.Wrappers;
using PgfPlots.Net.Public.Exceptions;
using PgfPlots.Net.Public.Interfaces.Services;
using Shouldly;

namespace PgfPlots.Net.Tests.Services;

public class PgfPlotSourceGeneratorTests
{
	private readonly IPgfPlotSourceGenerator _sourceGenerator = new PgfPlotSourceGenerator();
	
	[Fact]
	public void GeneratesSourceWithValidPgfPlotDefinition()
	{
		PgfPlotDefinition definition = new(new(), new());
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
		PgfPlotDefinition definition = new(null!, new());
		PgfPlotsGeneratorException ex = Should.Throw<PgfPlotsGeneratorException>(() => _sourceGenerator.GenerateSourceCode(definition));
		ex.InnerException.ShouldNotBeNull();
	}
}