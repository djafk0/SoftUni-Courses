using System;

namespace _2._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char bla = input[i];
                if (bla > Math.Min(a,b) && bla < Math.Max(b,a))
                {
                    sum += bla;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
