using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());

            double commission = 0;

            if (city == "Sofia")
            {
                if (0 <= sells && sells <= 500)
                {
                    commission = 0.05;
                }
                else if (500 < sells && sells <= 1000)
                {
                    commission = 0.07;
                }
                else if (1000 < sells && sells <= 10000)
                {
                    commission = 0.08;
                }
                else if (sells > 10000)
                {
                    commission = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (0 <= sells && sells <= 500)
                {
                    commission = 0.045;
                }
                else if (500 < sells && sells <= 1000)
                {
                    commission = 0.075;
                }
                else if (1000 < sells && sells <= 10000)
                {
                    commission = 0.1;
                }
                else if (sells > 10000)
                {
                    commission = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (0 <= sells && sells <= 500)
                {
                    commission = 0.055;
                }
                else if (500 < sells && sells <= 1000)
                {
                    commission = 0.08;
                }
                else if (1000 < sells && sells <= 10000)
                {
                    commission = 0.12;
                }
                else if (sells > 10000)
                {
                    commission = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            double result = sells * commission;
            if (result > 0)
            {
                Console.WriteLine($"{result:f2}");
            }
            else if (result < 0)
            {
                Console.WriteLine("error");
            }
        }
    }
}
