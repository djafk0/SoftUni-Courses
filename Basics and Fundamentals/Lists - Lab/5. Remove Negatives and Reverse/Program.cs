using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .Where(x => x >= 0)
                .ToList();

            if (input.Count > 0)
            {
                Console.WriteLine(string.Join(' ', input));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
