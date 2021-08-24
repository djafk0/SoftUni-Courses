using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "Craft!")
            {
                if (command[0] == "Collect" && !input.Contains(command[1]))
                {
                    input.Add(command[1]);
                }
                else if (command[0] == "Drop" && input.Contains(command[1]))
                {
                    input.Remove(command[1]);
                }
                else if (command[0] == "Combine Items")
                {
                    string[] combinedItems = command[1]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    if (input.Contains(combinedItems[0]))
                    {
                        bool oldItem = false;
                        int i = 0;
                        for (i = 0; i < input.Count; i++)
                        {
                            if (input[i] == combinedItems[0])
                            {
                                oldItem = true;
                                break;
                            }
                        }
                        if (oldItem)
                        {
                        input.Insert(i + 1, combinedItems[1]);
                        }
                    }
                }
                else if (command[0] == "Renew" && input.Contains(command[1]))
                {
                    input.Remove(command[1]);
                    input.Add(command[1]);
                }


                command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
