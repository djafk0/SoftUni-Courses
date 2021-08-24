using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            
            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "Go")
            {
                if (command[0] == "Urgent" && !input.Contains(command[1]))
                {
                    input.Insert(0, command[1]);
                }
                else if (command[0] == "Unnecessary" && input.Contains(command[1]))
                {
                    input.Remove(command[1]);
                }
                else if (command[0] == "Correct" && input.Contains(command[1]))
                {
                    int i = 0;
                    bool oldItem = false;
                    for (i = 0; i < input.Count; i++)
                    {
                        if (input[i] == command[1])
                        {
                            oldItem = true;
                            break;
                        }
                    }
                    if (oldItem)
                    {
                        input[i] = command[2];
                    }
                }
                else if (command[0] == "Rearrange" && input.Contains(command[1]))
                {
                    input.Remove(command[1]);
                    input.Add(command[1]);
                }


                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
