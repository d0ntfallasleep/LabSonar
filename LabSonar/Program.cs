using System;
using System.Collections.Generic;
using System.Linq; // Додав, бо треба для Count()

namespace NetSdrClient
{
    // FIX 1: Змінив class на static class (бо він містить тільки static Main)
    public static class Program
    {
        // FIX 2 & 3: Видалив publicField, оскільки воно не використовується і порушує інкапсуляцію.
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // FIX 4: Видалив unusedVar
            // int unusedVar = 123; 

            // FIX 5: Видалив закоментований код
            // int y = 20;
            // Console.WriteLine(y);
            try
            {
                DoSomethingClean(); 
            }
            // FIX 6: Додав обробку помилки (тепер не пустий catch)
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
            // FIX 7 & 8: Прибрав Magic Number (100) та зменшив вкладеність (об'єднав if)
            // (Тепер це також вирішує проблему з Complexity)
            int a = 5;
            const int MAX_VALUE = 100; // Виніс Magic Number в константу
            if (a > 0 && a < MAX_VALUE)
            {
                Console.WriteLine("A is mostly normal"); 
            }
        }
        // ПРИВАТНИЙ МЕТОД: Винесена спільна логіка
        private static string GetLevelDescription(int value)
        {
            if (value < 0)
            {
                return "Invalid value";
            }
            if (value == 0)
            {
                return "Zero";
            }
            if (value <= 50)
            {
                return "Low";
            }
            else if (value <= 100)
            {
                return "Normal";
            }
            else
            {
                return "High";
            }
        }
        public static string AnalyzeSpeed(int speed)
        {
            string level = GetLevelDescription(speed); // ВИКОРИСТАННЯ ПОМІЧНИКА

            return level switch
            {
                "Invalid value" => "Invalid value: Speed cannot be negative. Check sensor input.",
                "Zero" => "Stopped: Vehicle is completely stationary.",
                "Low" => "Low speed",
                "Normal" => "Normal speed",
                "High" => "High speed",
                _ => "Unknown speed state"
            };
        }
        // ... і так само для AnalyzeHeight
        public static string AnalyzeHeight(int height)
        {
            string level = GetLevelDescription(height);

            return level switch
            {
                "Invalid value" => "Invalid value: Speed cannot be negative. Check sensor input.",
                "Zero" => "Stopped: Vehicle is completely stationary.",
                "Low" => "Low speed",
                "Normal" => "Normal speed",
                "High" => "High speed",
                _ => "Unknown speed state"
            };
        }
        // ... і так само для AnalyzeHeight
    

    

// ... існуючий код ...
        public static int CalculateScore(int value) 
        {
            if (value > 100) return 10;
            if (value > 50) return 5;
            if (value < 0) return -1;
            return 0;
        }

        // FIX 9: Змінив назву методу на PascalCase
        public static void DoSomethingClean()
        {
            // FIX 10: Видалив пустий цикл
            /*
            for (int i = 0; i < 5; i++)
            {
            }
            */
            
            List<string> list = new List<string>();
            
            // FIX 11: Використовую .Count замість .Count() (краща продуктивність)
            if (list.Count == 0) 
            {
                Console.WriteLine("Empty");
            }
            
            // Новий метод для демонстрації покриття
            

            // FIX 12: Додав перевірку на null, щоб уникнути Vulnerability
            // До речі, Vulnerability (V-1) у тебе був на ній.
            string someString = null;
            if (someString is null)
            {
                Console.WriteLine("String is null.");
            }
        }
    }
}
// Final run triggerівфвіф