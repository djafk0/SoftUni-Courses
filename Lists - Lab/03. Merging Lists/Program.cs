using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> finalList = new List<int>();

            int diff = Math.Abs(firstList.Count - secondList.Count);

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count) + diff; i++)
            {
                if (i < Math.Min(firstList.Count, secondList.Count))
                {
                    finalList.Add(firstList[i]);
                    finalList.Add(secondList[i]);
                }
                else
                {
                    if (firstList.Count >= secondList.Count)
                    {
                        finalList.Add(firstList[i]);
                    }
                    else
                    {
                        finalList.Add(secondList[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', finalList));
        }
    }
}
