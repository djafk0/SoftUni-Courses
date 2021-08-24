using System;
using System.Collections.Generic;
using System.Linq;

namespace _3rd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split('%', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "Shop!")
            {
                if (command[0] == "Important")
                {
                    int index = input.FindIndex(x => x == command[1]);
                    if (index >= 0)
                    {
                        input.RemoveAt(index);
                        input.Insert(0, command[1]);
                    }
                    else
                    {
                        input.Insert(0, command[1]);
                    }
                }
                else if (command[0] == "Add")
                {
                    int index = input.FindIndex(x => x == command[1]);
                    if (index>= 0)
                    {
                        Console.WriteLine("The product is already in the list.");
                    }
                    else
                    {
                        input.Add(command[1]);
                    }
                }
                else if (command[0] == "Swap")
                {
                    int index1 = input.FindIndex(x => x == command[1]);
                    int index2 = input.FindIndex(x => x == command[2]);
                    if (index1 >= 0 && index2 >= 0)
                    {
                        input[index1] = command[2];
                        input[index2] = command[1];
                    }
                    else
                    {
                        if (index1>= 0)
                        {
                            Console.WriteLine($"Product {command[2]} missing!");
                        }
                        else if (index2 >= 0)
                        {
                            Console.WriteLine($"Product {command[1]} missing!");
                        }
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = input.FindIndex(x => x == command[1]);
                    if (index>= 0)
                    {
                        input.Remove(command[1]);
                    }
                    else
                    {
                        Console.WriteLine($"Product {command[1]} isn't in the list.");
                    }
                }
                else if (command[0] == "Reversed:")
                {
                    input.Reverse();
                }



                command = Console.ReadLine()
                .Split('%', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {input[i]}");
            }
        }
    }
}
