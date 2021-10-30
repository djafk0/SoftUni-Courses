using System;

namespace _01.USDtoBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            const double USDtoBGN = 1.79549;

            double input = double.Parse(Console.ReadLine());

            double result = input * USDtoBGN;

            Console.WriteLine(result);
        }
    }
}
