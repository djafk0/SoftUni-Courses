using System;

namespace leftAndRightSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum1 += number;
            }
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum2 += number;
            }
            if (sum2 == sum1)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                int total = Math.Abs(sum1 - sum2);
                Console.WriteLine($"No, diff = {total}");
            }
        }
    }
}
