using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> dic = new Dictionary<double, int>();

            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

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
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
