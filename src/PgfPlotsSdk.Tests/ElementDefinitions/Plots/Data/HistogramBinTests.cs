using PgfPlotsSdk.Public.ElementDefinitions.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.ElementDefinitions.Plots.Data;

public class HistogramBinTests
{
	private readonly HistogramBin<float> _bin;

	public HistogramBinTests()
	{
		_bin = new(0, 1);
	}

	[Fact]
	public void CanAddValueInBinRange()
	{
		_bin.TryAddToBin(0.5f).ShouldBeTrue();
		_bin.Frequency.ShouldBe(1);
	}

	[Fact]
	public void CanAddValueEqualToFloor()
	{
		_bin.TryAddToBin(0f).ShouldBeTrue();
		_bin.Frequency.ShouldBe(1);
	}

	[Fact]
	public void CantAddValueNotInBinRange()
	{
		_bin.TryAddToBin(1.5f).ShouldBeFalse();
		_bin.Frequency.ShouldBe(0);
	}

	[Fact]
	public void CantAddValueEqualToCeiling()
	{
		_bin.TryAddToBin(1f).ShouldBeFalse();
		_bin.Frequency.ShouldBe(0);
	}

	[Fact]
	public void CalculatesCentre()
	{
		_bin.Centre.ShouldBe(0.5f);
	}

	[Fact]
	public void FrequencyIsCounted()
	{
		for (int i = 0; i < 5; i++)
		{
			_bin.TryAddToBin(0.5f);
		}

		_bin.Frequency.ShouldBe(5);
	}
}