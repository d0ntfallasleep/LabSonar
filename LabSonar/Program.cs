using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting NetSdrClient...");

            int a = 5;
            int b = 10;
            int result = CalculateSum(a, b);

            Console.WriteLine($"Result is: {result}");

            // --- СПЕЦІАЛЬНИЙ CODE SMELL ДЛЯ SONARCLOUD ---
            // SonarCloud підсвітить цю змінну як "Unused variable" (невикористана змінна).
            // Це нормально! Ми хочемо побачити, як працює аналізатор.
            int unusedVariable = 100; 
            
            // Ще один приклад: закоментований код, який Sonar теж не любить
            // Console.WriteLine("This is commented out code");
        }

        static int CalculateSum(int x, int y)
        {
            return x + y;
        }
    }
