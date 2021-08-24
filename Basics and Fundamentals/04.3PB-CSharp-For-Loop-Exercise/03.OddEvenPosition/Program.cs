using System;

namespace _03.OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;
            double evenSum = 0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (number > evenMax) evenMax = number;
                    if (number < evenMin) evenMin = number;
                }
                else
                {
                    oddSum += number;
                    if (number > oddMax) oddMax = number;
                    if (number < oddMin) oddMin = number;
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");
            if (oddSum == 0) { Console.WriteLine($"OddMin=No,"); Console.WriteLine($"OddMax=No,"); }
            else { Console.WriteLine($"OddMin={oddMin:f2},"); Console.WriteLine($"OddMax={oddMax:f2},"); }

            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenSum == 0) { Console.WriteLine($"EvenMin=No,"); Console.WriteLine($"EvenMax=No"); }
            else { Console.WriteLine($"EvenMin={evenMin:f2},"); Console.WriteLine($"EvenMax={evenMax:f2}"); }
        }
    }
}
