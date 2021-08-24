using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    input.Add(command[1]);
                }
                else if (command[0] == "Remove")
                {
                    input.Remove(command[1]);
                }
                else if (command[0] == "RemoveAt")
                {
                    input.RemoveAt(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    input.Insert(int.Parse(command[2]), command[1]);
                }

                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(' ', input));
        }
    }
}
