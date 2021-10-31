using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> action = names => Console.WriteLine($"Sir {string.Join($"{Environment.NewLine}Sir ", names)}");

            action(input);
        }
    }
}
