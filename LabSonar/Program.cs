using System;
using System.Collections.Generic;

namespace NetSdrClient
{
    // SMELL 1: Static class should be used if only static methods, or correct class structure
    public class Program
    {
        // SMELL 2: Public field instead of property (Bad encapsulation)
        // SMELL 3: Naming convention violation (Should be PascalCase: PublicField)
        public int publicField = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // SMELL 4: Unused variable
            int unusedVar = 123;

            // SMELL 5: Commented out code (Sonar hates this)
            // int y = 20;
            // Console.WriteLine(y);

            try
            {
                DoSomething();
            }
            catch (Exception ex)
            {
                // SMELL 6: Empty catch block (Critical smell!)
            }
            
            // SMELL 7: Cognitive Complexity & Magic Numbers
            // SMELL 8: Nested IFs
            int a = 5;
            if (a > 0)
            {
                if (a < 100) // 100 is a "Magic Number"
                {
                    Console.WriteLine("A is mostly normal"); 
                }
            }
        }

        // SMELL 9: Method name not PascalCase (should be DoSomething)
        public static void DoSomething()
        {
            // SMELL 10: Loop with empty body
            for (int i = 0; i < 5; i++)
            {
            }
            
            List<string> list = new List<string>();
            // SMELL 11: Use of .Count() instead of .Count property on List (Performance)
            if (list.Count == 0) 
            {
                Console.WriteLine("Empty");
            }
        }
    }
}
// Final run trigger