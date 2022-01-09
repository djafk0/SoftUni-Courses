using System;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            Char(a, b);
        }

        private static void Char(char a, char b)
        {
            char lower = (char)Math.Min(a, b);
            char bigger = (char)Math.Max(a, b);
            for (int i = lower + 1; i < bigger; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
