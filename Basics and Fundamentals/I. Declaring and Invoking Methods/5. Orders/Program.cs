using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());
            double price = 0;
            double result = 0;
            result = OrderMethod(product, number, ref price);
        }

        private static double OrderMethod(string product, double number, ref double price)
        {
            double result;
            if (product == "coffee")
            {
                price = 1.5;
            }
            else if (product == "water")
            {
                price = 1;
            }
            else if (product == "coke")
            {
                price = 1.4;
            }
            else if (product == "snacks")
            {
                price = 2;
            }

            result = number * price;
            Console.WriteLine($"{result:f2}");
            return result;
        }
    }
}
