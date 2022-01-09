using System;

namespace _07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string userResponse = (Console.ReadLine());
            if (userResponse == ($"square"))
            {
                double square = double.Parse(Console.ReadLine());
                double square1 = square * square;
                Console.WriteLine($"{square1:f3}");
            }
            else if (userResponse == ($"rectangle"))
            {
                double rectangle = double.Parse(Console.ReadLine());
                double rectangle1 = double.Parse(Console.ReadLine());
                double rectangle2 = rectangle * rectangle1;
                Console.WriteLine($"{rectangle2:f3}");
            }
            else if (userResponse == ($"circle"))
            {
                double circle = double.Parse(Console.ReadLine());
                double circle1 = circle * circle * Math.PI;
                Console.WriteLine($"{circle1:f3}");
            }
            else if (userResponse == ($"triangle"))
            {
                double triangle = double.Parse(Console.ReadLine());
                double triangle1 = double.Parse(Console.ReadLine());
                double triangle2 = triangle * triangle1 / 2;
                Console.WriteLine($"{triangle2:f3}");
            }
        }
    }
}
