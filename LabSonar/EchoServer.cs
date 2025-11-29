using LabSonar.Application;

namespace NetSdrClient
{
    public class EchoServer
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public EchoServer(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public string GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "Error: Message is empty.";
            }
            if (_dateTimeProvider.Now.Hour >= 22 || _dateTimeProvider.Now.Hour < 6)
            {
                return $"[NIGHT ECHO] {message}";
            }
            else
            {
                return $"[DAY ECHO] {message}";
            }
        }
    }
}