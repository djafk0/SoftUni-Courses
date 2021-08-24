using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Mixed_Up_Lists
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
                .Reverse()
                .ToList();
            int lowerNumber = 0;
            int biggerNumber = 0;
            if (firstList.Count > secondList.Count)
            {
                lowerNumber = Math.Min(firstList[firstList.Count - 2], firstList[firstList.Count - 1]);
                biggerNumber = Math.Max(firstList[firstList.Count - 2], firstList[firstList.Count - 1]);
            }
            else
            {
                lowerNumber = Math.Min(secondList[secondList.Count - 2], secondList[secondList.Count - 1]);
                biggerNumber = Math.Max(secondList[secondList.Count - 2], secondList[secondList.Count - 1]);

            }
            List<int> finalList = new List<int>();

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                finalList.Add(firstList[i]);
                finalList.Add(secondList[i]);
            }

            finalList.RemoveAll(x => x >= biggerNumber);
            finalList.RemoveAll(x => x <= lowerNumber);

            finalList.Sort();
            Console.WriteLine(string.Join(' ', finalList));
        }
    }
}
