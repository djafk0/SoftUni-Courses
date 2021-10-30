
using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int packs = 1;

            for (int i = 0; i < numbers.Count;)
            {
                int curr = numbers.Peek();
                if (sum + curr <= capacity)
                {
                    sum += numbers.Pop();
                }
                else
                {
                    sum = 0;
                    packs++;
                }
            }

            Console.WriteLine(packs);
        }
    }
}
