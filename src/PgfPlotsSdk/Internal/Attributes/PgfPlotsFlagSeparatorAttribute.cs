namespace PgfPlotsSdk.Internal.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class PgfPlotsFlagSeparatorAttribute: Attribute
{
	public PgfPlotsFlagSeparatorAttribute(string separator)
	{
		Separator = separator;
	}
	public string Separator { get; }
}