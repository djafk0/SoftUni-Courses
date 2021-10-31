using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dic = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (dic.ContainsKey(name) == false)
                {
                    dic.Add(name, new List<decimal>());
                }

                dic[name].Add(grade);
            }

            foreach (var item in dic)
            {
                    Console.WriteLine($"{item.Key} -> {string.Join(' ', item.Value.Select(x => x.ToString("F2")))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
