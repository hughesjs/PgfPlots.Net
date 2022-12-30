using System.Collections;
using PgfPlotsSdk.Public.ElementDefinitions.Options;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots;

public class PlotDefinition<TData>: PlotDefinition
{
    private readonly TData[] _data;
    public override TData[] GetData() => _data;

    public PlotDefinition(PlotOptions plotOptions, TData[] data) : base(plotOptions, data.Cast<object>())
    {
        _data = data;
    }
}

public class PlotDefinition
{
    public PlotOptions PlotOptions { get; }
    
    private readonly IEnumerable? _data;

    public PlotDefinition(PlotOptions plotOptions, IEnumerable data)
    {
        PlotOptions = plotOptions;
        _data = data;
    }

    public virtual IEnumerable GetData() => _data ?? Array.Empty<object>();
}