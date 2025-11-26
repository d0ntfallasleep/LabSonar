using Xunit;
using NetSdrClient;
using LabSonar.Application;
using System;

namespace NetSdrClientAppTests;

// MOCK: Фейкова реалізація. Ми кажемо їй, котра година, і вона слухається.
public class FakeDateTimeProvider : IDateTimeProvider
{
    public DateTime TimeToReturn { get; set; }
    public DateTime Now => TimeToReturn;
}

public class EchoServerTests
{
    [Fact]
    public void GetResponse_Should_Return_Error_If_Message_Is_Empty()
    {
        // Arrange
        var fakeTime = new FakeDateTimeProvider(); // Час тут не важливий
        var server = new EchoServer(fakeTime);

        // Act
        var result = server.GetResponse("");

        // Assert
        Assert.Equal("Error: Message is empty.", result);
    }

    [Fact]
    public void GetResponse_Should_Return_DayEcho_At_10_AM()
    {
        // Arrange: Встановлюємо час на 10:00 ранку
        var fakeTime = new FakeDateTimeProvider 
        { 
            TimeToReturn = new DateTime(2025, 1, 1, 10, 0, 0) 
        };
        var server = new EchoServer(fakeTime);

        // Act
        var result = server.GetResponse("Hello");

        // Assert
        Assert.Equal("[DAY ECHO] Hello", result);
    }

    [Fact]
    public void GetResponse_Should_Return_NightEcho_At_11_PM()
    {
        // Arrange: Встановлюємо час на 23:00 (Ніч)
        // Завдяки рефакторингу ми можемо протестувати "ніч" навіть вдень!
        var fakeTime = new FakeDateTimeProvider 
        { 
            TimeToReturn = new DateTime(2025, 1, 1, 23, 0, 0) 
        };
        var server = new EchoServer(fakeTime);

        // Act
        var result = server.GetResponse("Hello");

        // Assert
        Assert.Equal("[NIGHT ECHO] Hello", result);
    }
}