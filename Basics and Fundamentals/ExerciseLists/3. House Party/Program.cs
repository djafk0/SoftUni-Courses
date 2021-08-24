using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < n; i++)
            {

                string[] name = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (name[2] == "going!")
                {
                    if (!names.Contains(name[0]))
                    {
                        names.Add(name[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{name[0]} is already in the list!");
                    }
                }
                else
                {
                    if (names.Contains(name[0]))
                    {
                        names.Remove(name[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{name[0]} is not in the list!");
                    }
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
