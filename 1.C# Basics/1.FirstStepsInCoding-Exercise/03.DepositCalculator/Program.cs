using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double percentPerYear = double.Parse(Console.ReadLine());

            double totalSum = depositSum + months * ((depositSum * (percentPerYear / 100)) / 12);

            Console.WriteLine(totalSum);
        }
    }
}
