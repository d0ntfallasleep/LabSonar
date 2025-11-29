using Xunit;
using NetSdrClient; 

namespace NetSdrClientAppTests;

public class ScoreCalculatorTests
{
    // Тест 1
    [Fact]
    public void CalculateScore_ValueOver100_ReturnsTen()
    {
        
        int value = 150;
        
        
        int result = Program.CalculateScore(value);
        
        
        Assert.Equal(10, result);
    }

    // Тест 2
    [Fact]
    public void CalculateScore_ValueBetween50And100_ReturnsFive()
    {
        int value = 75;
        int result = Program.CalculateScore(value);
        Assert.Equal(5, result);
    }
    
    // Тест 3
    [Fact]
    public void CalculateScore_ValueIsNegative_ReturnsMinusOne()
    {
        int value = -5;
        int result = Program.CalculateScore(value);
        Assert.Equal(-1, result);
    }
    
    // Тест 4
    [Fact]
    public void CalculateScore_ValueIsZero_ReturnsZero()
    {
        int value = 0;
        int result = Program.CalculateScore(value);
        Assert.Equal(0, result);
    }
    
    // Тест 5
    [Fact]
    public void CalculateScore_ValueIsFifty_ReturnsZero()
    {
        int value = 50;
        int result = Program.CalculateScore(value);
        Assert.Equal(0, result);
    }
}