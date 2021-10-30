using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (char i = (char)097; i < (char)097 + n; i++)
            {
                for (char j = (char)097; j < (char)097 + n; j++)
                {
                    for (char k = (char)097; k < (char)097 + n; k++)
                    {
                        Console.Write($"{i}{j}{k}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
