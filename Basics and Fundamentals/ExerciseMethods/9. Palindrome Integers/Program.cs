using System;
using System.Linq;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string savedInput = input.ToString();
            string reversedInput = "";
            for (int j = 0; j < int.MaxValue; j++)
            {
                for (int i = 0; i < input;)
                {
                    reversedInput += (input % 10).ToString();
                    input /= 10;
                }
                if (savedInput == reversedInput)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                savedInput = Console.ReadLine();
                if (savedInput == "END")
                {
                    break;
                }
                else
                {
                    input = int.Parse(savedInput);
                    reversedInput = "";
                }
            }
        }
    }
}
