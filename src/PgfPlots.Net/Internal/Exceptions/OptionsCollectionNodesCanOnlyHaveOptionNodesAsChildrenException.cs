namespace PgfPlots.Net.Internal.Exceptions;

internal class OptionsCollectionNodesCanOnlyHaveOptionNodesAsChildrenException: Exception
{
    public OptionsCollectionNodesCanOnlyHaveOptionNodesAsChildrenException() : base("Options collection nodes can only have option nodes as children"){}
}