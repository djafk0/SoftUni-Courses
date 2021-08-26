using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] curr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int op = curr[0];
                if (op == 1)
                {
                    numbers.Push(curr[1]);
                }
                else if (op == 2 && numbers.Count > 0)
                {
                    numbers.Pop();
                }
                else if (op == 3 && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (op == 4 && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
