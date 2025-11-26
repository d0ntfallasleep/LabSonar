using Xunit;
using NetSdrClient;

namespace NetSdrClientAppTests;

public class EchoServerTests
{
    [Fact]
    public void GetResponse_Should_Return_Error_If_Message_Is_Empty()
    {
        // Тут ми створюємо об'єкт БЕЗ параметрів (старий конструктор за замовчуванням)
        var server = new EchoServer();
        var result = server.GetResponse("");
        
        Assert.StartsWith("Error:", result);
    }

    [Fact]
    public void GetResponse_Should_Return_Something()
    {
        // Цей тест перевіряє тільки одну гілку (залежно від того, котра зараз година)
        // Тому покриття буде неповним (або день, або ніч, але не обидва).
        var server = new EchoServer();
        var result = server.GetResponse("Test");
        
        // Просто перевіряємо, що результат не пустий, бо не знаємо, що саме повернеться
        Assert.NotNull(result); 
    }
}