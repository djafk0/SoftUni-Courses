using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int n = numbers.Count / 2;
            for (int i = 1; i <= n; i++)
            {
                numbers[i - 1] += numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
