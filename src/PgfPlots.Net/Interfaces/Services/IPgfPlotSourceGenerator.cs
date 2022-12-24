using PgfPlots.Net.ElementDefinitions;

namespace PgfPlots.Net.Interfaces.Services;

public interface IPgfPlotSourceGenerator
{
    public string GenerateSourceCode(PgfPlotDefinition plotDefinition);
}