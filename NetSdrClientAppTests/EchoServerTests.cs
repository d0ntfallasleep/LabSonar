using Xunit;
using NetSdrClient;
using LabSonar.Application;
using System;

namespace NetSdrClientAppTests;


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
        
        var fakeTime = new FakeDateTimeProvider(); 
        var server = new EchoServer(fakeTime);

      
        var result = server.GetResponse("");

        
        Assert.Equal("Error: Message is empty.", result);
    }

    [Fact]
    public void GetResponse_Should_Return_DayEcho_At_10_AM()
    {
        var fakeTime = new FakeDateTimeProvider 
        { 
            TimeToReturn = new DateTime(2025, 1, 1, 10, 0, 0) 
        };
        var server = new EchoServer(fakeTime);

       
        var result = server.GetResponse("Hello");

        
        Assert.Equal("[DAY ECHO] Hello", result);
    }

    [Fact]
    public void GetResponse_Should_Return_NightEcho_At_11_PM()
    {
        
        var fakeTime = new FakeDateTimeProvider 
        { 
            TimeToReturn = new DateTime(2025, 1, 1, 23, 0, 0) 
        };
        var server = new EchoServer(fakeTime);

        
        var result = server.GetResponse("Hello");
        
        Assert.Equal("[NIGHT ECHO] Hello", result);
    }
}