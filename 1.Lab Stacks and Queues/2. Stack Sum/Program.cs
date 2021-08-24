using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>(input);

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToUpper() != "END")
            {
                if (command[0].ToUpper() == "ADD")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0].ToUpper() == "REMOVE")
                {
                    if (int.Parse(command[1]) < numbers.Count)
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numbers.Pop();
                        }
                    }
                }


                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
