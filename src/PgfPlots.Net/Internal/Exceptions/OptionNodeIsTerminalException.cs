namespace PgfPlots.Net.Internal.Exceptions;

internal class OptionNodeIsTerminalException: Exception
{
    public OptionNodeIsTerminalException() : base("Options nodes can't have children"){}
}