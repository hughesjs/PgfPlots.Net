namespace PgfPlotsSdk.Internal.Exceptions;

internal class InvalidPgfPlotBuildStateException: Exception
{
	public InvalidPgfPlotBuildStateException(string message) : base(message) { }
}