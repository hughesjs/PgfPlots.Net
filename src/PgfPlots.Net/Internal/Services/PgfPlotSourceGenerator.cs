using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Wrappers;
using PgfPlots.Net.Public.Exceptions;
using PgfPlots.Net.Public.Interfaces.Services;

namespace PgfPlots.Net.Internal.Services;

internal class PgfPlotSourceGenerator: IPgfPlotSourceGenerator
{
	//TODO - Make top level wrappers derive from something or just don't make figure optional
	
	public string GenerateSourceCode(FigureDefinition plotDefinition)
	{
		try
		{
			PgfPlotSyntaxTree tree = new(plotDefinition);
			string source = tree.GenerateSource();
			return source;
		}
		catch (Exception ex)
		{
			throw new PgfPlotsGeneratorException(ex);
		}
	}
	
	public string GenerateSourceCode(PgfPlotDefinition plotDefinition)
	{
		try
		{
			PgfPlotSyntaxTree tree = new(plotDefinition);
			string source = tree.GenerateSource();
			return source;
		}
		catch (Exception ex)
		{
			throw new PgfPlotsGeneratorException(ex);
		}
	}
}