using Xunit;
using NetSdrClient; // Обов'язково додаємо посилання на простір імен нашого коду

namespace NetSdrClientAppTests;

public class ScoreCalculatorTests
{
    // Тест 1: Позитивний шлях (value > 100)
    [Fact]
    public void CalculateScore_ValueOver100_ReturnsTen()
    {
        // Arrange
        int value = 150;
        
        // Act
        int result = Program.CalculateScore(value);
        
        // Assert
        Assert.Equal(10, result);
    }

    // Тест 2: Середній шлях (50 < value <= 100)
    [Fact]
    public void CalculateScore_ValueBetween50And100_ReturnsFive()
    {
        int value = 75;
        int result = Program.CalculateScore(value);
        Assert.Equal(5, result);
    }
    
    // Тест 3: Негативний шлях (value < 0)
    [Fact]
    public void CalculateScore_ValueIsNegative_ReturnsMinusOne()
    {
        int value = -5;
        int result = Program.CalculateScore(value);
        Assert.Equal(-1, result);
    }
    
    // Тест 4: Шлях за замовчуванням (0 <= value <= 50)
    [Fact]
    public void CalculateScore_ValueIsZero_ReturnsZero()
    {
        int value = 0;
        int result = Program.CalculateScore(value);
        Assert.Equal(0, result);
    }
    
    // Тест 5: Граничне значення (Перевірка, що 50 дає 0)
    [Fact]
    public void CalculateScore_ValueIsFifty_ReturnsZero()
    {
        int value = 50;
        int result = Program.CalculateScore(value);
        Assert.Equal(0, result);
    }
}