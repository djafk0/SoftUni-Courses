using System;

namespace _4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] remover = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string ban = "";
            string input = Console.ReadLine();
            for (int i = 0; i < remover.Length; i++)
            {
                if (input.Contains(remover[i]))
                {
                    for (int j = 0; j < remover[i].Length; j++)
                    {
                        ban += "*";
                    }
                    input = input.Replace(remover[i], ban);
                    ban = "";
                }
            }
            Console.WriteLine(input);
        }
    }
}
