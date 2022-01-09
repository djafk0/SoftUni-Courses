using System;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int sum = Sum(a, b);
            int subtract = Subtract(c, sum);
            Console.WriteLine(subtract);
        }

        private static int Subtract(int c, int sum)
        {
            return sum - c;
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
