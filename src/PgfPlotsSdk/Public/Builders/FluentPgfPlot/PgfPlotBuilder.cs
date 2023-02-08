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
	ICanAddAxisContentsOrSetAxisOptionsOrBuild,
	ICanAddPieContentsOrSetPieOptionsOrBuild,
	ICanAddWrapperOrAddRoot,
	ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions
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

	public static ICanAddWrapperOrAddRoot CreateBuilder() => new PgfPlotBuilder();

	public ICanAddAxisContents<ICanAddAxisContentsOrSetAxisOptionsOrBuild> AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options = null)
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
			return new()
			{
				Caption = _figureCaption,
				Label = _figureLabel,
				Plots = definitions.ToList()
			};
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
		_isPie = true;
		PlotDefinition plotDefinition = new(options ?? new(), slices.Cast<ILatexData>().ToArray());
		_plotDefinitions.Add(plotDefinition);
		return this;
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild AddPlot(IEnumerable<ILatexData> data, PlotOptions? options = null)
	{
		_isPie = false;
		PlotDefinition plotDefinition = new(options ?? new(), data.ToArray());
		_plotDefinitions.Add(plotDefinition);
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

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXLabel(string? label)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYLabel(string? label)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXMin(float? xMin)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYMin(float? yMin)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXMax(float? xMax)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYMax(float? yMax)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMinorXTickNumber(int? tickNum)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMinorYTickNumber(int? tickNum)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMajorXTickNumber(int? tickNum)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetMajorYTickNumber(int? tickNum)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetXTicks(List<float>? ticks)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetYTicks(List<float>? ticks)
	{
		throw new NotImplementedException();
	}

	public ICanAddAxisContentsOrSetAxisOptionsOrBuild SetGrid(GridSetting? grid)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetPieChartType(PieType? type)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetCentrePosition(LatexPosition? position)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetRotation(float? rotation)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetRadius(float? radius)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetSliceColours(List<LatexColour>? sliceColours)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetSliceExplosionFactors(List<float>? explosionFactors)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetReferenceSum(float? sum)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetScaleFont(bool? enabled)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetHideNumber(bool? enabled)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetBeforeNumberText(string beforeText)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetAfterNumberText(string? afterText)
	{
		throw new NotImplementedException();
	}

	public ICanAddPieContentsOrSetPieOptionsOrBuild SetTextPosition(PieTextOption? textPosition)
	{
		throw new NotImplementedException();
	}

	public ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions SetPlacementFlag(PositionFlags flagsToSet)
	{
		throw new NotImplementedException();
	}
}