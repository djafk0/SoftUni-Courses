using System;

namespace _01ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string input = Console.ReadLine();
            while (password != input)
            {
                input = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");

        }
    }
}
