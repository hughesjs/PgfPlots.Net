using PgfPlots.Net.Public.ElementDefinitions;

namespace PgfPlots.Net.Public.Interfaces.Services;

public interface IPgfPlotSourceGenerator
{
    public string GenerateSourceCode(PgfPlotDefinition plotDefinition);
}