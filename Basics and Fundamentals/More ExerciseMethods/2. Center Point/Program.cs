﻿using System;

namespace _2._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            CenterPoint(x1, y1, x2, y2);
        }

        private static void CenterPoint(double x1, double y1, double x2, double y2)
        {
            if (Math.Abs(x1) + Math.Abs(y1) <= Math.Abs(x2) + Math.Abs(y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
