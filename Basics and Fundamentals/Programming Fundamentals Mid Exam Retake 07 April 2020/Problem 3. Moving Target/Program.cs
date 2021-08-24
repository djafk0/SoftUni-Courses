using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Moving_Target
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

            while (command[0] != "End")
            {
                string action = command[0];
                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);

                if (action == "Shoot")
                {
                    if (index > input.Count - 1)
                    {
                        command = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                        continue;
                    }
                    int currNum = input[index];
                    currNum -= value;
                    if (currNum <= value)
                    {
                        input.RemoveAt(index);
                    }
                    else
                    {
                        input.RemoveAt(index);
                        input.Insert(index, currNum);
                    }
                }
                else if (action == "Add")
                {
                    if (index > input.Count - 1)
                    {
                        Console.WriteLine($"Invalid placement!");
                        command = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                        continue;
                    }
                    input.Insert(index, value);
                }
                else if (action == "Strike")
                {
                    if (index - value < 0 && index + value > input.Count - 1)
                    {
                        Console.WriteLine($"Strike missed!");
                        command = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                        continue;
                    }
                    else
                    {
                        int currNum = input[index];
                        for (int i = index + 1; i <= index + value; i++)
                        {
                            input.RemoveAt(i);
                        input.RemoveAt(index);
                        }
                        for (int i = index - 1; i >= Math.Max(value, index) - Math.Min(value, index); i--)
                        {
                            input.RemoveAt(i);
                        }
                    }
                }

                command = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }
            Console.WriteLine(string.Join('|', input));
        }
    }
}
