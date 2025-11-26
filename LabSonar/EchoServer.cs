using System;

namespace NetSdrClient
{
    // Цей клас важко тестувати, бо він напряму залежить від DateTime.Now
    public class EchoServer
    {
        // У "старій" версії немає конструктора і немає інтерфейсів
        public string GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "Error: Message is empty.";
            }

            // ЖОРСТКА ЗАЛЕЖНІСТЬ: DateTime.Now
            // Ми не можемо перевірити обидві гілки (день/ніч) в одному запуску тестів
            if (DateTime.Now.Hour >= 22 || DateTime.Now.Hour < 6)
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