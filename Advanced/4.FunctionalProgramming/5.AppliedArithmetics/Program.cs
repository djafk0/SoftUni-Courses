using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(s => s + 1).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(s => s * 2).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(s => s - 1).ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
