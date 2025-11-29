using Xunit;
using NetSdrClient;

namespace NetSdrClientAppTests;

public class ProgramTests
{
    [Theory]
    [InlineData(-1, "Invalid value: Speed cannot be negative. Check sensor input.")]
    [InlineData(0, "Stopped: Vehicle is completely stationary.")]
    [InlineData(10, "Low speed")]
    [InlineData(60, "Normal speed")]
    [InlineData(150, "High speed")]
    public void AnalyzeSpeed_ShouldReturnCorrectDescription(int speed, string expected)
    {
        var result = Program.AnalyzeSpeed(speed);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-5, "Invalid value: Height cannot be negative. Check sensor input.")]
    [InlineData(0, "Ground level: Altitude is zero.")]
    [InlineData(40, "Low height")]
    [InlineData(90, "Normal height")]
    [InlineData(200, "Great height")]
    public void AnalyzeHeight_ShouldReturnCorrectDescription(int height, string expected)
    {
        var result = Program.AnalyzeHeight(height);
        Assert.Equal(expected, result);
    }
}