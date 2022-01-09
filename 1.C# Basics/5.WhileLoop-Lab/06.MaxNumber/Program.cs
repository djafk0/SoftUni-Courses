using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    Console.WriteLine(max);
                    break;
                }
                int number = int.Parse(input);
                if (number > max)
                {
                    max = number;
                }
            }
        }
    }
}
