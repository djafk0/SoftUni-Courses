using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "End")
            {

                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    if (int.Parse(command[2]) >= numbers.Count || int.Parse(command[2]) < 0)
                    {
                        Console.WriteLine($"Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (int.Parse(command[1]) >= numbers.Count || int.Parse(command[1]) < 0)
                    {
                        Console.WriteLine($"Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(command[1]));

                    }
                }
                else if (command[1] == "left")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        if (int.Parse(command[2]) > numbers.Count && int.Parse(command[2]) <= 0)
                        {
                            Console.WriteLine($"Invalid index");
                            break;
                        }
                        int savedNumber = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(savedNumber);
                    }
                }
                else if (command[1] == "right")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {

                        if (int.Parse(command[2]) > numbers.Count && int.Parse(command[2]) <= 0)
                        {
                            Console.WriteLine($"Invalid index");
                            break;
                        }
                        int savedNumber = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, savedNumber);
                    }
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
