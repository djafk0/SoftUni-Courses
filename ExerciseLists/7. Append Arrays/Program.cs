using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<int> result = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int[] inputInt = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < inputInt.Length; j++)
                {
                    result.Add(inputInt[j]);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
