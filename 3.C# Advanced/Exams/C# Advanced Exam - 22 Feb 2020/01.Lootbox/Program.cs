using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> second = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int myBox = 0;

            while (first.Count != 0 && second.Count != 0)
            {
                if ((first.Peek() + second.Peek()) % 2 == 0)
                {
                    myBox += first.Dequeue() + second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }

                if (first.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                }
                else if (second.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                }
            }

            if (myBox >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {myBox}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {myBox}");
            }

        }
    }
}
