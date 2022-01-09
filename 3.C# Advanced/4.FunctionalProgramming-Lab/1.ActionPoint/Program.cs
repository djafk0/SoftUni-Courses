using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> action = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            action(input);
        }
    }
}
