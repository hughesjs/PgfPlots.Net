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

		Should.NotThrow(() => _bins.AddBin(binZero));
		Should.NotThrow(() => _bins.AddBin(binOne));
		Should.NotThrow(() => _bins.AddBin(binTwo));
		
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

		Should.NotThrow(() => _bins.AddBin(binOne));
		Should.Throw<HistogramBinOverlapException<int>>(() => _bins.AddBin(binTwo));
		
		_bins.Count.ShouldBe(1);
	}

	[Fact]
	public void GeneratesCorrectLatex()
	{
		HistogramBin<int> binZero = new(-2,-1);
		HistogramBin<int> binOne = new(0, 10);
		HistogramBin<int> binTwo = new(10, 15);

		_bins.AddBin(binZero);
		_bins.AddBin(binOne);
		_bins.AddBin(binTwo);
		
		_bins.AddValueToBin(-2);
		_bins.AddValueToBin(1);
		_bins.AddValueToBin(2);
		_bins.AddValueToBin(3);
		_bins.AddValueToBin(10);
		_bins.AddValueToBin(11);
		_bins.AddValueToBin(12);
		_bins.AddValueToBin(13);
		
		_bins.GetDataLatexString().ShouldBe("(-2,1) (0,3) (10,4) (15,0)");
	}
}