using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            int openingBracket = 0;
            int closingBracket = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    openingBracket = indexes.Pop();
                    Console.WriteLine(input.Substring(openingBracket, i - openingBracket + 1));
                }
            }
        }
    }
}
