using PgfPlotsSdk.Internal.Exceptions;
using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.ElementDefinitions.Plots.Data;

public class HistogramBinCollectionTests
{
	private readonly HistogramBinCollection<int> _bins;

	public HistogramBinCollectionTests()
	{
		_bins = new();
	}

	[Fact]
	public void CanAddConsecutiveBins()
	{
		HistogramBin<int> binZero = new(-2,-1);
		HistogramBin<int> binOne = new(0, 10);
		HistogramBin<int> binTwo = new(10, 15);

		Should.NotThrow(() => _bins.Add(binZero));
		Should.NotThrow(() => _bins.Add(binOne));
		Should.NotThrow(() => _bins.Add(binTwo));
		
		_bins.Count.ShouldBe(3);
	}

	[Theory]
	[InlineData(9, 15)]
	[InlineData(2, 4)]
	[InlineData(-1, 0)]
	public void CantAddOverlappingBins(int binTwoFloor, int binTwoCeiling)
	{
		HistogramBin<int> binOne = new(0, 10);
		HistogramBin<int> binTwo = new(binTwoFloor, binTwoCeiling);

		Should.NotThrow(() => _bins.Add(binOne));
		Should.Throw<HistogramBinOverlapException<int>>(() => _bins.Add(binTwo));
		
		_bins.Count.ShouldBe(1);
	}

	[Fact]
	public void GeneratesCorrectLatex()
	{
		HistogramBin<int> binZero = new(-2,-1);
		binZero.TryAddToBin(-2);
		
		HistogramBin<int> binOne = new(0, 10);
		binOne.TryAddToBin(1);
		binOne.TryAddToBin(2);
		binOne.TryAddToBin(3);
		
		HistogramBin<int> binTwo = new(10, 15);
		binTwo.TryAddToBin(10);
		binTwo.TryAddToBin(11);
		binTwo.TryAddToBin(12);
		binTwo.TryAddToBin(13);
		
		_bins.Add(binZero);
		_bins.Add(binOne);
		_bins.Add(binTwo);
		
		_bins.GetDataLatexString().ShouldBe("(-2,1) (0,3) (10,4) (15,0)");
	}
}