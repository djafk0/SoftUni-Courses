using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();

                if (!dic.ContainsKey(value))
                {
                    dic.Add(value, 0);
                }

                dic[value] += 1;
            }

            Console.WriteLine(dic.First(x => x.Value % 2 == 0).Key);
        }
    }
}
