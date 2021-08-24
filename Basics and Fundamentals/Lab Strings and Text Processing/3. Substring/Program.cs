using System;
using System.Linq;

namespace _3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string remover = Console.ReadLine();
            string input = Console.ReadLine();

            while (input.Contains(remover))
            {
                int location = input.IndexOf(remover);
                input = input.Remove(location, remover.Length);
            }
            Console.WriteLine(string.Join("", input));

        }
    }
}
