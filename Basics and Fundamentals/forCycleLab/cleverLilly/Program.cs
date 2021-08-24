using System;

namespace cleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double laundry = double.Parse(Console.ReadLine());
            double priceOfToys = double.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    evenSum += 10 + evenSum - 10;
                }
            }
            Console.WriteLine(evenSum);
        }
    }
}
