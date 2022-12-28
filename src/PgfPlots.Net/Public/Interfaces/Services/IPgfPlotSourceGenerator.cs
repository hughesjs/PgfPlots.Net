using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Wrappers;

namespace PgfPlots.Net.Public.Interfaces.Services;

public interface IPgfPlotSourceGenerator
{
    public string GenerateSourceCode(PgfPlotDefinition plotDefinition);
}