using System;
using System.Collections.Generic;

namespace _5.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> dic = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (dic.ContainsKey(input[i]) == false)
                {
                    dic.Add(input[i], 0);
                }

                dic[input[i]] += 1;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
