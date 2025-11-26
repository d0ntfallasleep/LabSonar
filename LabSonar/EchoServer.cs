using LabSonar.Application;

namespace NetSdrClient
{
    // Клас тепер придатний до тестування (Inversion of Control)
    public class EchoServer
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        // Тепер залежність вводиться через конструктор
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

            // Використовуємо інжектовану залежність
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