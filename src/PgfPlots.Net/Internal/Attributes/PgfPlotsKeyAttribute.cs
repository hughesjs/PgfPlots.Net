namespace PgfPlots.Net.Internal.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class PgfPlotsKeyAttribute: Attribute
{
    public PgfPlotsKeyAttribute(string keyName)
    {
        KeyName = keyName;
    }
    
    public string KeyName { get; }
}