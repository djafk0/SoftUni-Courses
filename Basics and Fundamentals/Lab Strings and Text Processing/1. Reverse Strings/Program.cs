using System;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                Console.Write($"{word} = ");
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    Console.Write($"{word[i]}");
                }
                Console.WriteLine();
                word = Console.ReadLine();
            }

        }
    }
}
