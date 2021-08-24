using System;

namespace _3._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int result = 0;
            result = MathCalculations(type, a, b, result);
            Console.WriteLine(result);

        }

        private static int MathCalculations(string type, int a, int b, int result)
        {
            if (type == "add")
            {
                result = a + b;
            }
            else if (type == "multiply")
            {
                result = a * b;
            }
            else if (type == "subtract")
            {
                result = a - b;
            }
            else if (type == "divide")
            {
                result = a / b;
            }

            return result;
        }
    }
}
