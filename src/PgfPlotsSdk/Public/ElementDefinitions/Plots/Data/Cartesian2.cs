namespace PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

public class Cartesian2<T>: PlotData
{
    public Cartesian2(T x, T y)
    {
        X = x;
        Y = y;
    }

    public T X { get; }
    public T Y { get; }

    public override string GetDataLatexString() => $"({X},{Y})";
}