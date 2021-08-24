using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double average = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                average += numbers[i];
            }

            double result = average / numbers.Count;

            numbers.RemoveAll(x => x <= result);
            numbers.Sort();
            numbers.Reverse();
            if (numbers.Count > 5)
            {
                int off = numbers.Count - 5;
                numbers.RemoveRange(5, off);
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
            Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
