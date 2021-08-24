using System;

namespace _5._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            if (first > 0 && second > 0 && third > 0 || first < 0 && second < 0 || first < 0 && third < 0 || second < 0 && third < 0)
            {
                Console.WriteLine("positive");
            }
            else if (first == 0 || second == 0 || third == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
