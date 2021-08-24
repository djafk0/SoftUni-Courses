using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());
            NewMethod(number, n);
        }

        private static void NewMethod(double number, double n)
        {
            double result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= number;
            }
            Console.WriteLine(result);
        }
    }
}
