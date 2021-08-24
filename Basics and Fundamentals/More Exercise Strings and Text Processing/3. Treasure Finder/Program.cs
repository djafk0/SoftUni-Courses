using System;
using System.Text;

namespace _3._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                int bla = input.IndexOf('>');
                int number = bla + 1;
                input.Remove(number);
            }
        }
    }
}
