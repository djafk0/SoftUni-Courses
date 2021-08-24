using System;

namespace _07.ConcatName
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine($"{a}{delimeter}{b}");
        }
    }
}
