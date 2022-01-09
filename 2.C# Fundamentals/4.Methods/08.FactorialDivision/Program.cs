
using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int fact = int.Parse(Console.ReadLine());
            int divider = int.Parse(Console.ReadLine());
            long factF = 1;
            long divideF = 1;
            factF = Fact(fact, factF);
            divideF = Fact(divider, divideF);
            double result = (double)factF / divideF;
            Console.WriteLine($"{result:f2}");

        }

        private static long Fact(int fact, long factF)
        {
            for (int i = 1; i <= fact; i++)
            {
                factF *= i;
            }

            return factF;
        }
    }
}
