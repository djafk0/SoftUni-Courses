using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> names = new Queue<string>(input);
            int n = int.Parse(Console.ReadLine());

            while (names.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    names.Enqueue(names.Dequeue());
                }
                Console.WriteLine($"Removed {names.Dequeue()}");
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
