using System.Numerics;
using PgfPlotsSdk.Internal.ElementDefinitions;
using PgfPlotsSdk.Internal.Exceptions;
using PgfPlotsSdk.Internal.SyntaxTree;
using PgfPlotsSdk.Public.Exceptions;
using PgfPlotsSdk.Public.Generated;
using PgfPlotsSdk.Public.Interfaces.Data;
using PgfPlotsSdk.Public.Models.Enums;
using PgfPlotsSdk.Public.Models.Options;
using PgfPlotsSdk.Public.Models.Plots.Data;

namespace PgfPlotsSdk.Public.Builders;

public class PgfPlotBuilder: IPgfPlotBuilder
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

    
    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid AddPgfPlotWithAxes(AxisType axisType, AxisOptions? options)
    {
        _axisType = axisType;
        _axisOptions = options ?? new();
        return this;
    }

    public ICanAddPie AddPgfPlot()
    {
        // This may do something later. At the moment, it just makes the API a bit more sane.
        return this;
    }

    public ICanAddPgfPlotWithAxesOrAddPgfPlotOrSetCaptionOrSetLabelOrSetPlacementFlag AddFigure(FigureOptions? figureOptions)
    {
        _figureOptions = figureOptions ?? new();
        return this;
    }

    public static ICanAddPgfPlotWithAxesOrAddPgfPlotOrAddFigure CreateBuilder() => new PgfPlotBuilder();

    public ICanAddPgfPlotWithAxesOrAddPgfPlotOrSetCaptionOrSetLabelOrSetPlacementFlag SetCaption(string? caption)
    {
        _figureCaption = caption;
        return this;
    }

    public ICanAddPgfPlotWithAxesOrAddPgfPlotOrSetCaptionOrSetLabelOrSetPlacementFlag SetLabel(string? label)
    {
        _figureLabel = label;
        return this;
    }

    public ICanAddPgfPlotWithAxesOrAddPgfPlotOrSetCaptionOrSetLabelOrSetPlacementFlag SetPlacementFlag(PositionFlags flagsToSet)
    {
        _figureOptions ??= new();
        _figureOptions.Position ??= 0;
        _figureOptions.Position |= flagsToSet;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks AddPlot(
        IEnumerable<ILatexData> data, PlotOptions? options)
    {
        SavePrevious(ref _plotOptions);
		
        _isPie = false;
        _currentData = data.ToArray();
        _plotOptions = options ?? new();
		
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors AddPie<T>(IEnumerable<PieChartSliceData<T>> slices, PieChartOptions? options) where T : INumber<T>
    {
        SavePrevious(ref _pieChartOptions );
		
        _isPie = true;
        _currentData = slices.Cast<ILatexData>().ToArray();
        _pieChartOptions = options ?? new();
		
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetRadius(float? radius)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.Radius = radius;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetHideNumber(bool? enabled)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.HideNumber = enabled;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetReferenceSum(float? referenceSum)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.ReferenceSum = referenceSum;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetRotation(float? rotation)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.Rotation = rotation;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetCentrePosition(float x, float y)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.CentrePosition = new(x, y);
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetScaleFont(bool? enabled)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.ScaleFont = enabled;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetSliceColours(params LatexColour[] colours)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.SliceColours = colours.ToList();
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetTextPosition(PieTextOption? textPosition)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.TextPosition = textPosition;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetAfterNumberText(string? afterText)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.AfterNumberText = afterText;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetBeforeNumberText(string? beforeText)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.BeforeNumberText = beforeText;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetPieChartType(PieType? type)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.PieChartType = type;
        return this;
    }

    public ICanAddPieOrBuildOrSetRadiusOrSetHideNumberOrSetReferenceSumOrSetRotationOrSetCentrePositionOrSetScaleFontOrSetSliceColoursOrSetTextPositionOrSetAfterNumberTextOrSetBeforeNumberTextOrSetPieChartTypeOrSetSliceExplosionFactors
        SetSliceExplosionFactors(params float[] factors)
    {
        _pieChartOptions ??= new();
        _pieChartOptions.SliceExplosionFactors = factors.ToList();
        return this;
    }

    public string Build()
    {
        try
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
        catch (Exception ex)
        {
            throw new PgfPlotsGeneratorException(ex);
        }
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetColour(LatexColour? colour)
    {
        _plotOptions ??= new();
        _plotOptions.Colour = colour;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetBarType(BarType? type)
    {
        _plotOptions ??= new();
        _plotOptions.BarType = type;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetMark(PlotMark? mark)
    {
        _plotOptions ??= new();
        _plotOptions.Mark = mark;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetSmooth(bool? enabled)
    {
        _plotOptions ??= new();
        _plotOptions.Smooth = enabled;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetBarWidth(float? width)
    {
        _plotOptions ??= new();
        _plotOptions.BarWidth = width;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetFillColour(LatexColour? colour)
    {
        _plotOptions ??= new();
        _plotOptions.FillColour = colour;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetFillOpacity(float? opacity)
    {
        _plotOptions ??= new();
        _plotOptions.FillOpacity = opacity;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetLineStyle(LineStyle? style)
    {
        _plotOptions ??= new();
        _plotOptions.LineStyle = style;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetLineWidth(float? width)
    {
        _plotOptions ??= new();
        _plotOptions.LineWidth = width;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetMarkSize(float? size)
    {
        _plotOptions ??= new();
        _plotOptions.MarkSize = size;
        return this;
    }

    public ICanAddPlotOrBuildOrSetColourOrSetBarTypeOrSetMarkOrSetSmoothOrSetBarWidthOrSetFillColourOrSetFillOpacityOrSetLineStyleOrSetLineWidthOrSetMarkSizeOrSetOnlyMarks
        SetOnlyMarks(bool? enabled)
    {
        _plotOptions ??= new();
        _plotOptions.OnlyMarks = enabled;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetXLabel(string? label)
    {
        _axisOptions ??= new();
        _axisOptions.XLabel = label;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetYLabel(string? label)
    {
        _axisOptions ??= new();
        _axisOptions.YLabel = label;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetXMin(float? min)
    {
        _axisOptions ??= new();
        _axisOptions.XMin = min;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetYMin(float? min)
    {
        _axisOptions ??= new();
        _axisOptions.YMin = min;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetXMax(float? max)
    {
        _axisOptions ??= new();
        _axisOptions.XMax = max;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetYMax(float? max)
    {
        _axisOptions ??= new();
        _axisOptions.YMax = max;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetMinorXTickNumber(int? number)
    {
        _axisOptions ??= new();
        _axisOptions.MinorXTickNumber = number;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetMinorYTickNumber(int? number)
    {
        _axisOptions ??= new();
        _axisOptions.MinorXTickNumber = number;
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetXTicks(params float[] ticks)
    {
        _axisOptions ??= new();
        _axisOptions.XTicks = ticks.ToList();
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetYTicks(params float[] ticks)
    {
        _axisOptions ??= new();
        _axisOptions.YTicks = ticks.ToList();
        return this;
    }

    public ICanAddPlotOrSetXLabelOrSetYLabelOrSetXMinOrSetYMinOrSetXMaxOrSetYMaxOrSetMinorXTickNumberOrSetMinorYTickNumberOrSetXTicksOrSetYTicksOrSetGrid SetGrid(GridSetting? grid)
    {
        _axisOptions ??= new();
        _axisOptions.Grid = grid;
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
    
    private FigureDefinition? GenerateFigure(params PgfPlotDefinition[] definitions)
    {
        if (_figureOptions is not null)
        {
            return new(_figureOptions, _figureLabel, _figureCaption, definitions);
        }

        return null;
    }
}