using PgfPlotsSdk.Public.Builders.FluentPgfPlot;
using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;
using PgfPlotsSdk.Public.Interfaces.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.Builders.FluentPgfPlot;

public class PgfPlotBuilderTests
{
	private readonly ICanAddWrapperOrAddRoot _root;

	private static readonly ILatexData[] Data1 =
	{
		new Cartesian2<int>(0, 1),
		new Cartesian2<int>(2, 3),
		new Cartesian2<int>(4, 5)
	};

	private static readonly ILatexData[] Data2 =
	{
		new Cartesian2<int>(5, 6),
		new Cartesian2<int>(7, 8),
		new Cartesian2<int>(8, 2)
	};

	public PgfPlotBuilderTests()
	{
		_root = PgfPlotBuilder.CreateBuilder();
	}

	[Fact]
	public void BuilderIsCreated()
	{
		_root.ShouldNotBeNull();
	}

	[Fact]
	public void CanCreateBasicPlot()
	{
		const string expected = """
								\begin{tikzpicture}
								\begin{axis}[]
								\addplot[]
								plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePlotWithAxisOptions()
	{
		const string expected = """
								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot[]
								plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard, new AxisOptions
			{
				XLabel = "XAxis",
				YLabel = "YAxis"
			})
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreatePlotWithBuiltAxisOptions()
	{
		const string expected = """
								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot[]
								plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.SetXLabel("XAxis")
			.SetYLabel("YAxis")
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreateChartWithTwoPlots()
	{
		const string expected = """
								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot[]
								plot coordinates {(0,1) (2,3) (4,5)};
								\addplot[]
								plot coordinates {(5,6) (7,8) (8,2)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard, new AxisOptions
			{
				XLabel = "XAxis",
				YLabel = "YAxis"
			})
			.AddPlot(Data1)
			.AddPlot(Data2)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePlotWithPlotOptions()
	{
		const string expected = """
								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot[ybar, only marks]
								plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard, new AxisOptions
			{
				XLabel = "XAxis",
				YLabel = "YAxis"
			})
			.AddPlot(Data1, new PlotOptions()
			{
				BarType = BarType.YBar,
				OnlyMarks = true
			})
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePlotWrappedInFigure()
	{
		const string expected = """
								\begin{figure}
								\begin{tikzpicture}
								\begin{axis}[]
								\addplot[]
								plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								\end{figure}
								""";
		string res = _root.AddFigure()
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanAddCaptionAndLabelToFigure()
	{
		const string expected = """
								\begin{figure}
								\begin{tikzpicture}
								\begin{axis}[]
								\addplot[]
								plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								\caption{This is my caption!}
								\label{fig:myfig}
								\end{figure}
								""";
		string res = _root.AddFigure()
			.SetCaption("This is my caption!")
			.SetLabel("fig:myfig")
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreateSimplePie()
	{
		const string expected = """
                                \begin{tikzpicture}
                                \pie []
                                {5, 10, 15};

                                \end{tikzpicture}
                                """;

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);
		PieChartSliceData<int>[] slices = { chartSliceOne, chartSliceTwo, chartSliceThree };

		string res = _root.AddPgfPlot()
			.AddPie(slices)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePieWithOptions()
	{
		const string expected = """
                                \begin{tikzpicture}
                                \pie [polar, pos={1,1}, radius=2.3, color={red,green,blue}, sum=30, scale font, after number=\%]
                                {5, 10, 15};

                                \end{tikzpicture}
                                """;

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);
		PieChartSliceData<int>[] slices = { chartSliceOne, chartSliceTwo, chartSliceThree };

		string res = _root.AddPgfPlot()
			.AddPie(slices, new PieChartOptions
			{
				CentrePosition = new(1, 1),
				ReferenceSum = 30,
				AfterNumberText = @"\%",
				Radius = 2.3f,
				PieChartType = PieType.Polar,
				ScaleFont = true,
				SliceColours = new() { LatexColour.Red, LatexColour.Green, LatexColour.Blue }
			})
			.Build();

		res.ShouldBe(expected);
	}
}