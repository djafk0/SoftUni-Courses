using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> numbers = new Stack<string>(input);

            while (numbers.Count > 1)
            {
                int a = int.Parse(numbers.Pop());
                string symbol = numbers.Pop();
                int b = int.Parse(numbers.Pop());

                if (symbol == "+")
                {
                    numbers.Push((a + b).ToString());
                }
                else
                {
                    numbers.Push((a - b).ToString());
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
