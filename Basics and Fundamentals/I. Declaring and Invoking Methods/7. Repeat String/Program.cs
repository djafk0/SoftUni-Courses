using System;

namespace _7._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            NewMethod(input, times);
        }

        private static string NewMethod(string input, int times)
        {
            string output = "";
            for (int i = 0; i < times; i++)
            {
                Console.Write(input);
            }
            return output;
        }
    }
}
