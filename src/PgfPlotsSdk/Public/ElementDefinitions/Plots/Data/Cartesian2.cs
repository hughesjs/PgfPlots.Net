using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;

public class Cartesian2<T>: ILatexData
{
    public Cartesian2(T x, T y)
    {
        X = x;
        Y = y;
    }

    public T X { get; }
    public T Y { get; }

    public string GetDataLatexString() => $"({X},{Y})";
}