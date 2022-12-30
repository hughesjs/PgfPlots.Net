[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/hughesjs/PgfPlotsSdk/dotnet-cd.yml?style=for-the-badge&branch=master)](https://github.com/hughesjs/PgfPlotsSdk/actions)
![GitHub top language](https://img.shields.io/github/languages/top/hughesjs/PgfPlotsSdk?style=for-the-badge)
[![GitHub](https://img.shields.io/github/license/hughesjs/PgfPlotsSdk?style=for-the-badge)](LICENSE)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/PgfPlotsSdk?style=for-the-badge)](https://nuget.org/packages/PgfPlotsSdk/)
[![Nuget](https://img.shields.io/nuget/dt/PgfPlotsSdk?style=for-the-badge)](https://nuget.org/packages/PgfPlotsSdk/)
![FTB](https://raw.githubusercontent.com/hughesjs/custom-badges/master/made-in/made-in-scotland.svg)

⚠ Please note, this SDK is still in very active development, features may be added and removed, although I will try and keep on top of using proper semantic versioning. ⚠

Help would be greatly appreciated with this one.

---

# PgfPlotsSdk

This is a C# library to enable developers to draw LaTex PGFPlots.

## Introduction

So far, only the very core of the library is in place. However, this is enough to plot line graphs, scatter plots, and bar charts using a reduced set of options. 

The [issue tracker](https://github.com/hughesjs/PgfPlotsSdk/) will show the most up to date roadmap, but the following is on the immediate roadmap:

- The ability to add and customise a legend.
- Builder classes to make it easier to produce common chart types without engaging directly with the element definitions if you don't want to.
- Pie charts
- Adding a linter

## How to Use

### Installing the Package

As with most C# packages, install it through Nuget via your IDE or the CLI.

`dotnet add <csproj> package PgfPlotsSdk`

It is also available as a package from the Github Image Repo.

### Configuring DI

Currently, the SDK is designed in such a way that it plugs in via `Microsoft.DependencyInjection`. If there is a big desire for this to change in the future, I might reconsider this.

For now, once you've got your `IServiceCollection`, you need to call the extension method `services.AddPgfPlotsServices()`.

From here, you'll be able to resolve or inject the `IPgfPlotSourceGenerator`.

```cs
ServiceCollection services = new();
services.AddPgfPlotsServices();
IServiceProvider provider = services.BuildServiceProvider();

IPgfPlotSourceGenerator service = provider.GetRequiredService<IPgfPlotSourceGenerator>();
```
### Creating a PgfPlot

Until such a time as there is a builder, you must construct you PgfPlot using the objects contained within the `PgfPlotsSdk.Public.ElementDefinitions` namespace.

#### Root Element

Currently, there are two root elements:
    - `PgfPlotDefinition` will result in your outermost element being the `tikzpicture` environment.
    - `FigureDefinition` will result in your outermost element being a `figure` with optional caption and label. This may contain any number of `tikzpicture`.

For instance, to create a figure with a caption and label, you'd use:

```cs
FigureDefinition figureDefinition = new()
{
    Caption = "I am the caption",
    Label = "fig:ex"
};		
```

Once this was passed through the generator, you'd end up with:

```tex
\begin{figure}
\caption{I am the caption}
\label{fig:ex}
\end{figure}
```

#### Defining Your Axes

Your axes are defined as part of the `PgfPlotDefinition`, since you have one set of axes per `PgfPlot`. 

These are configured through the `AxisOptions` class and passed into the `PgfPlotDefinition` constructor.

For instance:

```cs
private static readonly AxisOptions AxisOptions = new()
{
    XMin = -5,
    XMax = 5,
    XTicks = new() {-5, -3.2f, -1, 0, 1.2f, 4, 5},
    YMin = 0,
    YMax = 10,
    YTicks = new() {0, 3.3f, 6.2f, 8, 9, 10},
    MinorXTickNumber = 3,
    MinorYTickNumber = 4,
    XLabel = "I Am The X Label",
    YLabel = "I Am The Y Label"
};
```

This rather whackadoodle set of options would produce this LaTex output:

```tex
\begin{tikzpicture}
\begin{axis}[xlabel=I Am The X Label, ylabel=I Am The Y Label, xmin=-5, ymin=0, xmax=5, ymax=10, minor y tick num=4, minor x tick num=3, xtick={-5,-3.2,-1,0,1.2,4,5}, ytick={0,3.3,6.2,8,9,10}]
\end{axis}
\end{tikzpicture}
```

It's worth noting that not every option supported by PgfPlots has been implemented yet and neither has the ability to add custom keys.

#### Adding A Plot

Your plots themselves are defined with `PlotDefinition` objects and configured with `PlotOptions`, you also need to provide an `IEnumerable<PlotData>` containing your actual plotdata.

So far, there's only one plot-data class implemented `Cartesian2<T>` which represents a 2D cartesian coordinate with `T` typed elements.

To implement your own `PlotData` type, just inherit from `PlotData` and override `GetDataLatexString` such that it returns the LaTex source for each element. 

So to put all of this together, this set of options and data:

```cs
AxisOptions AxisOptions = new()
{
    XMin = -5,
    XMax = 5,
    XTicks = new() {-5, -3.2f, -1, 0, 1.2f, 4, 5},
    YMin = 0,
    YMax = 10,
    YTicks = new() {0, 3.3f, 6.2f, 8, 9, 10},
    MinorXTickNumber = 3,
    MinorYTickNumber = 4,
    XLabel = "I Am The X Label",
    YLabel = "I Am The Y Label"
};

List<Cartesian2<int>> Data = new()
{
    new(0,1),
    new(2,3),
    new(4,5)
};

PlotOptions plotOptions = new()
{
    Colour = LatexColour.Black,
    Mark = PlotMark.Diamond,
    MarkSize = 5,
    LineStyle = LineStyle.Dashed,
    LineWidth = 2f,
    Smooth = true,
    OnlyMarks = false
};

PlotDefinition plotDefinition = new(plotOptions, Data1);
PgfPlotDefinition pgfPlotDefinition = new(AxisOptions, new(){plotDefinition});
```

Would generate this LaTex source:

```tex
\begin{tikzpicture}
\begin{axis}[xlabel=I Am The X Label, ylabel=I Am The Y Label, xmin=-5, ymin=0, xmax=5, ymax=10, minor y tick num=4, minor x tick num=3, xtick={-5,-3.2,-1,0,1.2,4,5}, ytick={0,3.3,6.2,8,9,10}]
\addplot[color=black, mark=diamond, mark size=5, line width=2, dashed, smooth]
plot coordinates {(0,1) (2,3) (4,5)};
\end{axis}
\end{tikzpicture}
```

You can add as many plots as you like to your PgfPlotDefinition.

#### Generating the Source

Actually generating the source is easy once you've created your root definition and added everything to that.

Get an instance of `IPgfPlotSourceGenerator` from you DI container (be that through injection or resolution) and then pass your root element to `pgfPlotSourceGenerator.GenerateSource(rootElement)`.

### Rendering The Output

Currently, this SDK cannot render your LaTex, it is up to the consuming application to take the string output of the source generator and choose what to do with it. 

In the simplest case, the source can be dumped to a file and included with `\include{fPath}` into your LaTex document.