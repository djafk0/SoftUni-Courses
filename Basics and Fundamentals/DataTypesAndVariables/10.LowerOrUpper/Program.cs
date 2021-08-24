using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {

            char a = char.Parse(Console.ReadLine());
            char toUpperA = char.ToUpper(a);
            if (a == toUpperA)
            {
                Console.WriteLine($"upper-case");
            }
            else
            {
                Console.WriteLine($"lower-case");
            }
        }
    }
}
