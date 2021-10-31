using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Max());
            }

            if (numbers.Sum() <= food)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                while (true)
                {
                    int curr = numbers.Peek();
                    if (food - curr >= 0)
                    {
                        food -= numbers.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                
                Console.WriteLine($"Orders left: {string.Join(' ', numbers)}");
            }
        }
    }
}
