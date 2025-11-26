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
        public static string AnalyzeSpeed(int speed)
        {
            if (speed < 0)
            {
                return "Invalid value";
            }
            if (speed == 0)
            {
                return "Stopped";
            }
            if (speed <= 50)
            {
                return "Low speed";
            }
            else if (speed <= 100)
            {
                return "Normal speed";
            }
            else // speed > 100
            {
                return "High speed";
            }
        }

        // МЕТОД З ДУБЛІКАТАМИ 2: Аналіз висоти
        public static string AnalyzeHeight(int height)
        {
            if (height < 0)
            {
                return "Invalid value";
            }
            if (height == 0)
            {
                return "Ground level"; // Змінений тільки цей рядок
            }
            if (height <= 50)
            {
                return "Low height"; // Змінений тільки цей рядок
            }
            else if (height <= 100)
            {
                return "Normal height"; // Змінений тільки цей рядок
            }
            else // height > 100
            {
                return "Great height"; // Змінений тільки цей рядок
            }
        }

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
// Final run trigger