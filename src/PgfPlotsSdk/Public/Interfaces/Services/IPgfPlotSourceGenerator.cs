using PgfPlotsSdk.Public.ElementDefinitions;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

namespace PgfPlotsSdk.Public.Interfaces.Services;

public interface IPgfPlotSourceGenerator
{
    public string GenerateSourceCode(PgfPlotDefinition plotDefinition);
    public string GenerateSourceCode(FigureDefinition plotDefinition);
}