using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dimension[0];
            int m = dimension[1];
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> both = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in first)
            {
                if (second.Contains(item))
                {
                    both.Add(item);
                }
            }

            Console.WriteLine(string.Join(' ', both));
        }
    }
}
