using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            while (sum < n)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (sum >= n)
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
