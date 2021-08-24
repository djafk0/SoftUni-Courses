using System;

namespace _2k1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            while (n > sum)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number * 2 + 1;
            }
            Console.WriteLine(sum);
        }
    }
}
