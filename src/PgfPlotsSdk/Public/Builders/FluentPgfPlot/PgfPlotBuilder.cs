using System.Numerics;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.Builders.FluentPgfPlot;

public class PgfPlotBuilder: ICanCreateRoot, ICanAddAxisContents, ICanAddPieContents, ICanAddWrapperOrFigureDecorations
{
	private AxisOptions? _axisOptions;
	private AxisType? _axisType;
	private FigureOptions? _figureOptions;
	private string? _figureLabel;
	private string? _figureCaption;
	private bool _isPie;

	private readonly List<PlotDefinition> _plotDefinitions;
	private PgfPlotBuilder()
	{
		_plotDefinitions = new();
	}

	public static ICanCreateRoot CreateBuilder() => new PgfPlotBuilder();

	public ICanAddAxisContents AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options = null)
	{
		_axisType = axisType;
		_axisOptions = options ?? new();
		return this;
	}

	public ICanAddPieContents AddPgfPlot()
	{
		// This is here because it may be expanded with tikz options later and it makes the API a bit more sane
		return this;
	}

	public ICanAddWrapperOrFigureDecorations AddFigure(FigureOptions? figureOptions = null)
	{
		_figureOptions = figureOptions ?? new();
		return this;
	}

	public string Build() => _isPie ? BuildPieChart() : BuildPlot();

	private string BuildPlot()
	{
		throw new NotImplementedException();
	}

	private string BuildPieChart()
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContents AddPie<T>(IEnumerable<PieChartSliceData<T>> slices, PieChartOptions? options = null) where T : INumber<T>
	{
		_isPie = true;
		PlotDefinition plotDefinition = new(options, slices.Cast<ILatexData>().ToArray());
		_plotDefinitions.Add(plotDefinition);
		return this;
	}

	public ICanAddAxisContents AddPlot(IEnumerable<ILatexData> data, PlotOptions? options = null)
	{
		_isPie = false;
		PlotDefinition plotDefinition = new(options, data.ToArray());
		_plotDefinitions.Add(plotDefinition);
		return this;
	}

	public ICanAddWrapperOrFigureDecorations SetLabel(string? label)
	{
		_figureLabel = label;
		return this;
	}

	public ICanAddWrapperOrFigureDecorations SetCaption(string? caption)
	{
		_figureCaption = caption;
		return this;
	}
}