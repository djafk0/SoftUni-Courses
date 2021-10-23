using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int sum = 0;

            while (guests.Count != 0 && plates.Count != 0)
            {
                int curSum = 0;

                if ((plates.Peek() - guests.Peek()) > 0)
                {
                    sum += plates.Pop() - guests.Dequeue();
                }
                else
                {
                    while (true)
                    {
                        curSum += plates.Pop();

                        if (curSum == guests.Peek())
                        {
                            guests.Dequeue();
                            break;
                        }
                        else if (curSum > guests.Peek())
                        {
                            sum += curSum - guests.Dequeue();
                            break;
                        }
                    }
                }
            }

            if (plates.Count == 0)
            {
                Console.Write("Guests: ");
                Console.WriteLine(string.Join(' ', guests));
            }
            else
            {
                Console.Write("Plates: ");
                Console.WriteLine(string.Join(' ', plates));
            }

            Console.WriteLine($"Wasted grams of food: {sum}");
        }
    }
}
