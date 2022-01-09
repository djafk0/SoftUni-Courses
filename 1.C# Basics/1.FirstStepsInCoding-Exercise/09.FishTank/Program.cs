using System;

namespace _09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double result = length * width * height * 0.001 * ((100 - percent) / 100);

            Console.WriteLine(result);
        }
    }
}
