using System;

namespace _04.EvenPowersOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            double num = 1;
            for (int i = 0; i <= number; i += 2)
            {
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}
