using System;

namespace balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "NoMoreMoney")
                {
                    Console.WriteLine($"Total: {total:f2}");
                    break;
                }
                double num = double.Parse(input);
                if (num > 0)
                {
                    Console.WriteLine($"Increase: {num:f2}");
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {total:f2}");
                    break;
                }
                total += num;
            }
        }
    }
}
