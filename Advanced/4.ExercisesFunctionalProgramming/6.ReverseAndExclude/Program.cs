using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Func<int, bool> func = sort => sort % n != 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (!func(list[i]))
                {
                    list.Remove(list[i]);
                    i--;
                }
            }

            Console.WriteLine(string.Join(' ', list));
        }
    }
}
