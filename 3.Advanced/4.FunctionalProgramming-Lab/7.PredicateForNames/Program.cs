using System;
using System.Linq;

namespace _1.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s.Length <= n)));
        }
    }
}
