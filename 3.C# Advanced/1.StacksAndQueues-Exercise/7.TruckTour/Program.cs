using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> numbers = new Queue<int[]>();
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                int total = 0;

                foreach (var item in numbers)
                {
                    total += item[0];
                    total -= item[1];
                    if (total < 0)
                    {
                        numbers.Enqueue(numbers.Dequeue());
                        break;
                    }
                }

                if (total >= 0)
                {
                    break;
                }

                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}
