using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.Exceptions;
using PgfPlots.Net.Public.Interfaces.Services;

namespace PgfPlots.Net.Internal.Services;

internal class PgfPlotSourceGenerator: IPgfPlotSourceGenerator
{
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