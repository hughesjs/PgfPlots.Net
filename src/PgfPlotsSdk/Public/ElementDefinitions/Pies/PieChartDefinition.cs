using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Pies.Data;

namespace PgfPlotsSdk.Public.ElementDefinitions.Pies;

public class PieChartDefinition<T> where T: INumber<T>
{
	public PieChartOptions PieChartOptions { get; }
	public List<PieSliceData<T>> PieSliceData { get; }
	
	public PieChartDefinition(PieChartOptions pieChartOptions, List<PieSliceData<T>> pieSliceData)
	{
		PieChartOptions = pieChartOptions;
		PieSliceData = pieSliceData;
	}
}