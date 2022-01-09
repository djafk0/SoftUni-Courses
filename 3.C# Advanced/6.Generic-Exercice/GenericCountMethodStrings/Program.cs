using GenericSwapMethodStrings;
using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            
            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double value = double.Parse(Console.ReadLine());
            Box<double> comparableBox = new Box<double>(value);

            int count = GetGreaterThanCount(boxes, comparableBox);

            Console.WriteLine(count);
        }

        private static int GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;

            foreach (Box<T> item in boxes)
            {
                int compare = item.CompareTo(box);

                if (compare > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
