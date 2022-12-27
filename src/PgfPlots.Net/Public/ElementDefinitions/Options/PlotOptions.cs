using PgfPlots.Net.Internal.Attributes;
using PgfPlots.Net.Public.ElementDefinitions.Enums;

namespace PgfPlots.Net.Public.ElementDefinitions.Options;

public record PlotOptions: OptionsDefinition
{
    [PgfPlotsKey("color")]
    public LatexColour? Colour { get; init; }

    [PgfPlotsKey("red")]
    public float? Red
    {
        get => _red;
        init
        {
            if (value is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Red), value, "Colour values must be between 0 and 1");
            }

            _red = value;
        }
    }

    [PgfPlotsKey("green")]
    public float? Green
    {
        get => _green;
        init
        {
            if (value is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Green), value, "Colour values must be between 0 and 1");
            }

            _green = value;
        }
    }
    
    [PgfPlotsKey("blue")]
    public float? Blue
    {
        get => _blue;
        init
        {
            if (value is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Blue), value, "Colour values must be between 0 and 1");
            }

            _blue = value;
        }
    }
    
    [PgfPlotsKey("hue")]
    public float? Hue
    {
        get => _hue;
        init
        {
            if (value is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Hue), value, "Colour values must be between 0 and 1");
            }

            _hue = value;
        }
    }
    
    [PgfPlotsKey("saturation")]
    public float? Saturation
    {
        get => _saturation;
        init
        {
            if (value is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Saturation), value, "Colour values must be between 0 and 1");
            }

            _saturation = value;
        }
    }
    
    [PgfPlotsKey("brightness")]
    public float? Brightness
    {
        get => _brightness;
        init
        {
            if (value is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Brightness), value, "Colour values must be between 0 and 1");
            }

            _brightness = value;
        }
    }
    
    [PgfPlotsKey("mark")]
    public PlotMark? Mark { get; init; }
    
    [PgfPlotsKey("symbol")]
    public string? Symbol { get; init; }
    
    [PgfPlotsKey("mark size")]
    public float? MarkSize { get; init; }
    
    [PgfPlotsKey("line width")]
    public float? LineWidth { get; init; }
    
    [PgfPlotsKey("line style")]
    public LineStyle LineStyle { get; init; }
    
    [PgfPlotsKey("smooth")]
    public bool? Smooth { get; init; }
    
    [PgfPlotsKey("only marks")]
    public bool? OnlyMarks { get; init; }
    
    [PgfPlotsKey("name path")]
    public string? NamePath { get; init; }

    private readonly float? _blue;
    private readonly float? _red;
    private readonly float? _green;
    private readonly float? _hue;
    private readonly float? _saturation;
    private readonly float? _brightness;
    
    //TODO - Add custom keys dict
    
    //TODO - Add mark options
}