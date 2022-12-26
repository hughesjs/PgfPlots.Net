using System.Collections;
using System.Reflection;
using System.Text;
using PgfPlots.Net.Internal.Reflection;
using PgfPlots.Net.Public.ElementDefinitions;

namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

// TODO - Consider moving options into their own node
internal class AxisNode : SyntaxNode<AxisDefinition>
{
    protected override string BeforeChildren => """
                                                \begin{axis}
                                                """;

    protected override string AfterChildren => """
                                               
                                               \end{axis}
                                               """;

    public override StringBuilder GenerateSource(StringBuilder builder)
    {
        builder.Append(BeforeChildren);

        builder.Append("[");
        AppendOptionsFromAxisDefinition(builder);
        builder.Append("]\n");
        
        Children.ForEach(child => child.GenerateSource(builder));

        builder.Append(AfterChildren);
        return builder;
    }

    private void AppendOptionsFromAxisDefinition(StringBuilder builder)
    {
        foreach (PropertyInfo prop in Data.GetType().GetProperties())
        {
            string optionName = PgfPlotsKeyHelper.GetPgfPlotsKey<AxisDefinition>(prop.Name)
                                ?? prop.Name;

            MethodInfo? getter = prop.GetGetMethod();
            object? value = getter?.Invoke(Data, null);
            if (value is null) continue;

            Type dataType = value.GetType();
            
            
            if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
            {
                AppendListOption(builder, optionName, ((ICollection)value).OfType<object>());
                continue;
            }
            
            AppendBasicOption(builder, optionName, value);
        }

    }

    private static void AppendBasicOption(StringBuilder builder, string optionName, object value)
    {
        builder.Append(optionName);
        builder.Append("=");
        builder.Append(value);
        builder.Append(" ");
    }

private static void AppendListOption(StringBuilder builder, string optionName, IEnumerable<object> values)
    {
        builder.Append(optionName);
        builder.Append("={");
        foreach (object value in values)
        {
            builder.Append(value);
            builder.Append(",");
        }

        builder.Remove(builder.Length - 1, 1);
        builder.Append("} ");
    }
    
    public AxisNode(AxisDefinition data) : base(data) { }
    
    public AxisNode(SyntaxNode parent, AxisDefinition data) : base(parent, data) { }

    public AxisNode(SyntaxNode parent, List<SyntaxNode> children, AxisDefinition data) : base(parent, children, data) { }
}