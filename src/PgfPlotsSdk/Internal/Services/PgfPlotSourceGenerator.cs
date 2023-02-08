using PgfPlotsSdk.Internal.ElementDefinitions;
using PgfPlotsSdk.Internal.SyntaxTree;

namespace PgfPlotsSdk.Internal.Services;

internal class PgfPlotSourceGenerator
{
	//TODO - Make top level wrappers derive from something or just don't make figure optional

	public string GenerateSourceCode(FigureDefinition plotDefinition)
	{
		PgfPlotSyntaxTree tree = new(plotDefinition);
		string source = tree.GenerateSource();
		return source;
	}

	public string GenerateSourceCode(PgfPlotDefinition plotDefinition)
	{
		PgfPlotSyntaxTree tree = new(plotDefinition);
		string source = tree.GenerateSource();
		return source;
	}
}