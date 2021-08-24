using System;
using System.Collections.Generic;
using System.Linq;

namespace _2nd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "Finish")
            {
                if (command[0] == "Add")
                {
                    input.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    input.Remove(int.Parse(command[1]));
                }
                else if (command[0] == "Replace")
                {
                    int index = input.FindIndex(x => x == int.Parse(command[1]));
                    input.RemoveAt(index);
                    input.Insert(index, int.Parse(command[2]));
                }
                else if (command[0] == "Collapse")
                {
                    input.RemoveAll(x => x < int.Parse(command[1]));
                }




                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join(' ', input));
        }
    }
}
