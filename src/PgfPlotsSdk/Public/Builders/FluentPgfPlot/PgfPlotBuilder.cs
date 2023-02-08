using System.Numerics;
using PgfPlotsSdk.Internal.Exceptions;
using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Misc;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.ElementDefinitions.Wrappers;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;
using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Public.Builders.FluentPgfPlot;

public class PgfPlotBuilder: 
	ICanAddAxisPlotOrSetPlotOptionsOrBuild,
	ICanAddPieContentsOrSetPieOptionsOrBuild,
	ICanAddWrapperOrAddRoot,
	ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions,
	ICanAddAxisPlotOrSetAxisOptions
{
	private AxisType? _axisType;
	private AxisOptions? _axisOptions;
	private FigureOptions? _figureOptions;
	private PieChartOptions? _pieChartOptions;
	private PlotOptions? _plotOptions;
	private string? _figureLabel;
	private string? _figureCaption;
	private bool _isPie;

	private ILatexData[]? _currentData;

	private readonly List<PlotDefinition> _plotDefinitions;
	private PgfPlotBuilder()
	{
		_plotDefinitions = new();

	}

	public static ICanAddWrapperOrAddRoot CreateBuilder() => new PgfPlotBuilder();

	public ICanAddAxisPlotOrSetAxisOptions AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options = null)
	{
		_axisType = axisType;
		_axisOptions = options ?? new();
		return this;
	}
	

	public ICanAddPieContents<ICanAddPieContentsOrSetPieOptionsOrBuild> AddPgfPlot()
	{
		// This may do something later. At the moment, it just makes the API a bit more sane.
		return this;
	}


	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions AddFigure(FigureOptions? figureOptions = null)
	{
		_figureOptions = figureOptions ?? new();
		return this;
	}

	public string Build()
	{
		if (_isPie)
		{
			SavePrevious(ref _pieChartOptions);
		}
		else
		{
			SavePrevious(ref _plotOptions);
		}
		Validate();
		PlotDefinition[] plotDefinitions = _plotDefinitions.ToArray();
		PgfPlotDefinition definition = _isPie ? new PgfPlotDefinition(plotDefinitions) : new PgfPlotWithAxesDefinition(_axisOptions!, _axisType!.Value, plotDefinitions);
		FigureDefinition? figureDefinition = GenerateFigure(definition);

		PgfPlotSyntaxTree tree = figureDefinition is null ? new(definition) : new(figureDefinition);
		return tree.GenerateSource();
	}

	private FigureDefinition? GenerateFigure(params PgfPlotDefinition[] definitions)
	{
		if (_figureOptions is not null)
		{
			return new(_figureOptions, _figureLabel, _figureCaption, definitions);
		}

		return null;
	}
	

	private void Validate()
	{
		if (!_isPie)
		{
			if (_axisOptions is null || _axisType is null)
			{
				throw new InvalidPgfPlotBuildStateException("A non-pie plot requires axes");
			}
		}
	}



	public ICanAddPieContentsOrSetPieOptionsOrBuild AddPie<T>(IEnumerable<PieChartSliceData<T>> slices, PieChartOptions? options = null) where T : INumber<T>
	{
		SavePrevious(ref _plotOptions);
		
		_isPie = true;
		_currentData = slices.Cast<ILatexData>().ToArray();
		_pieChartOptions = options ?? new();
		
		return this;
	}

	private void SavePrevious<TOptions>(ref TOptions? options) where TOptions: OptionsDefinition, new()
	{
		if (_currentData is null) return;
		PlotDefinition plotDefinition = new(options ?? new(), _currentData);
		_plotDefinitions.Add(plotDefinition);
		_currentData = null;
		options = null;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild AddPlot(IEnumerable<ILatexData> data, PlotOptions? options = null)
	{
		SavePrevious(ref _plotOptions);
		
		_isPie = false;
		_currentData = data.ToArray();
		_plotOptions = options ?? new();
		
		return this;
	}

	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetLabel(string? label)
	{
		_figureLabel = label;
		return this;
	}

	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetCaption(string? caption)
	{
		_figureCaption = caption;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetXLabel(string? label)
	{
		_axisOptions ??= new();
		_axisOptions.XLabel = label;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetYLabel(string? label)
	{
		_axisOptions ??= new();
		_axisOptions.YLabel = label;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetXMin(float? xMin)
	{
		_axisOptions ??= new();
		_axisOptions.XMin = xMin;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetYMin(float? yMin)
	{
		_axisOptions ??= new();
		_axisOptions.YMin = yMin;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetXMax(float? xMax)
	{
		_axisOptions ??= new();
		_axisOptions.XMax = xMax;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetYMax(float? yMax)
	{
		_axisOptions ??= new();
		_axisOptions.YMax = yMax;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetMinorXTickNumber(int? tickNum)
	{
		_axisOptions ??= new();
		_axisOptions.MinorXTickNumber = tickNum;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetMinorYTickNumber(int? tickNum)
	{
		_axisOptions ??= new();
		_axisOptions.MajorYTickNumber = tickNum;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetMajorXTickNumber(int? tickNum)
	{
		_axisOptions ??= new();
		_axisOptions.MajorXTickNumber = tickNum;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetMajorYTickNumber(int? tickNum)
	{
		_axisOptions ??= new();
		_axisOptions.MajorYTickNumber = tickNum;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetXTicks(List<float>? ticks)
	{
		_axisOptions ??= new();
		_axisOptions.XTicks = ticks;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetYTicks(List<float>? ticks)
	{
		_axisOptions ??= new();
		_axisOptions.YTicks = ticks;
		return this;
	}

	public ICanAddAxisPlotOrSetAxisOptions SetGrid(GridSetting? grid)
	{
		_axisOptions ??= new();
		_axisOptions.Grid = grid;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetPieChartType(PieType? type)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.PieChartType = type;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetCentrePosition(float x, float y)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.CentrePosition = new(x, y);
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetRotation(float? rotation)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.Rotation = rotation;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetRadius(float? radius)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.Radius = radius;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetSliceColours(params LatexColour[] sliceColours)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.SliceColours = sliceColours.ToList();
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetSliceExplosionFactors(List<float>? explosionFactors)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.SliceExplosionFactors = explosionFactors;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetReferenceSum(float? sum)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.ReferenceSum = sum;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetScaleFont(bool? enabled)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.ScaleFont = enabled;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetHideNumber(bool? enabled)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.HideNumber = enabled;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetBeforeNumberText(string beforeText)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.BeforeNumberText = beforeText;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetAfterNumberText(string? afterText)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.AfterNumberText = afterText;
		return this;
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetTextPosition(PieTextOption? textPosition)
	{
		_pieChartOptions ??= new();
		_pieChartOptions.TextPosition = textPosition;
		return this;
	}

	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetPlacementFlag(PositionFlags flagsToSet)
	{
		_figureOptions ??= new();
		_figureOptions.Position ??= 0;
		_figureOptions.Position |= flagsToSet;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetColour(LatexColour? colour)
	{
		_plotOptions ??= new();
		_plotOptions.Colour = colour;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetMark(PlotMark? mark)
	{
		_plotOptions ??= new();
		_plotOptions.Mark = mark;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetMarkSize(float? size)
	{
		_plotOptions ??= new();
		_plotOptions.MarkSize = size;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetLineWidth(float? width)
	{
		_plotOptions ??= new();
		_plotOptions.LineWidth = width;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetFillOpacity(float? opacity)
	{
		_plotOptions ??= new();
		_plotOptions.FillOpacity = opacity;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetLineStyle(LineStyle? style)
	{
		_plotOptions ??= new();
		_plotOptions.LineStyle = style;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetBarType(BarType? type)
	{
		_plotOptions ??= new();
		_plotOptions.BarType = type;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetBarWidth(float? width)
	{
		_plotOptions ??= new();
		_plotOptions.BarWidth = width;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetFillColour(LatexColour? fillColour)
	{
		_plotOptions ??= new();
		_plotOptions.FillColour = fillColour;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetSmooth(bool? smooth)
	{
		_plotOptions ??= new();
		_plotOptions.Smooth = smooth;
		return this;
	}

	public ICanAddAxisPlotOrSetPlotOptionsOrBuild SetOnlyMarks(bool? onlyMarks)
	{
		_plotOptions ??= new();
		_plotOptions.OnlyMarks = onlyMarks;
		return this;
	}
}