using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string type = Console.ReadLine();

            Predicate<int> predicate = sort => sort % 2 == 0;
            List<int> numbers = new List<int>();

            for (int i = ranges[0]; i <= ranges[1]; i++)
            {
                numbers.Add(i);
            }

            if (type == "even")
            {
                foreach (var item in numbers)
                {
                    if (predicate(item))
                    {
                        Console.Write(item + " ");
                    }
                }
            }
            else if (type == "odd")
            {
                foreach (var item in numbers)
                {
                    if (predicate(item) == false)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }
    }
}
