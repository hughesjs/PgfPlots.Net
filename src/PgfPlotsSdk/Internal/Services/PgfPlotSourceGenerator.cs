using PgfPlotsSdk.Public.ElementDefinitions;
using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;
using PgfPlotsSdk.Public.Exceptions;
using PgfPlotsSdk.Public.Interfaces.Services;

namespace PgfPlotsSdk.Internal.Services;

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