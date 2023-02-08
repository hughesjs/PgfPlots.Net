namespace PgfPlotsSdk.Public.Exceptions;

public class PgfPlotsGeneratorException: Exception
{
	public PgfPlotsGeneratorException(Exception? innerException) : base("PGFPlot generation has failed, see inner exception for details.", innerException) { }
}