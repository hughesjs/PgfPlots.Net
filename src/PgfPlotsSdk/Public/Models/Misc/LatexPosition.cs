namespace PgfPlotsSdk.Public.Models.Misc;

public class LatexPosition
{
	public LatexPosition(float x, float y)
	{
		X = x;
		Y = y;
	}
	public float X { get; }
	public float Y { get; }

	public override string ToString() => $@"{{{X},{Y}}}";
}