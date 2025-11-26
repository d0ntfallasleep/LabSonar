using Xunit;
using NetSdrClient;

namespace NetSdrClientAppTests;

public class EchoServerTests
{
    [Fact]
    // Залиште тільки цей тест
    public void GetResponse_Should_Return_Error_If_Message_Is_Empty()
    {
        var server = new EchoServer();
        var result = server.GetResponse("");
        Assert.StartsWith("Error:", result);
    }
    // Інші тести видаліть!
}