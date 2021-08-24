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
            List<string> savedList = input;
            string[] command = Console.ReadLine().Split().ToArray();
            bool flag = false;
            while (command[0] != "end")
            {
                List<int> inputInt = input.Select(int.Parse).ToList();
                if (command[0] == "Add")
                {
                    input.Add(command[1]);
                    flag = true;
                }
                else if (command[0] == "Remove")
                {
                    input.Remove(command[1]);
                    flag = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    input.RemoveAt(int.Parse(command[1]));
                    flag = true;
                }
                else if (command[0] == "Insert")
                {
                    input.Insert(int.Parse(command[2]), command[1]);
                    flag = true;
                }
                else if (command[0] == "Contains")
                {
                    if (input.Contains(command[1]))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (inputInt[i] % 2 == 0)
                        {
                            Console.Write(inputInt[i] + " ");
                        }
                    }
                    Console.WriteLine();

                }
                else if (command[0] == "PrintOdd")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (inputInt[i] % 2 == 1)
                        {
                            Console.Write(inputInt[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (command[0] == "GetSum")
                {
                    int sum = 0;
                    for (int i = 0; i < input.Count; i++)
                    {
                        sum += inputInt[i];
                    }
                    Console.WriteLine(sum);
                }
                else if (command[0] == "Filter")
                {
                    int filterNumber = int.Parse(command[2]);
                    if (command[1] == "<")
                    {
                        List<int> filteredList = input.Select(int.Parse).Where(x => x < (int.Parse(command[2]))).ToList();
                        Console.WriteLine(string.Join(' ', filteredList));
                    }
                    else if (command[1] == ">")
                    {
                        List<int> filteredList = input.Select(int.Parse).Where(x => x > (int.Parse(command[2]))).ToList();
                        Console.WriteLine(string.Join(' ', filteredList));
                    }
                    else if (command[1] == ">=")
                    {
                        List<int> filteredList = input.Select(int.Parse).Where(x => x >= (int.Parse(command[2]))).ToList();
                        Console.WriteLine(string.Join(' ', filteredList));
                    }
                    else if (command[1] == "<=")
                    {
                        List<int> filteredList = input.Select(int.Parse).Where(x => x <= (int.Parse(command[2]))).ToList();
                        Console.WriteLine(string.Join(' ', filteredList));
                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            // there is the problem
            if (flag)
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
