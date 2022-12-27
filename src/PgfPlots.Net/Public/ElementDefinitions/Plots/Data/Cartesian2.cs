namespace PgfPlots.Net.Public.ElementDefinitions.Plots.Data;

public struct Cartesian2<T>
{
    public Cartesian2(T x, T y)
    {
        X = x;
        Y = y;
    }

    public T X { get; }
    public T Y { get; }

    public override string ToString() => $"({X},{Y})";
}