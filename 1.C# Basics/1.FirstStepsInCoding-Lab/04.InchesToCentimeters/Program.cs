using System;

namespace _04.InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double sm = double.Parse(Console.ReadLine());

            double inch = 2.54;

            double smInch = sm * inch;

            Console.WriteLine(smInch);
        }
    }
}
