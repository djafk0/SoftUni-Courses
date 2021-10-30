using System;

namespace _10.InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if ((100 <= num && num <= 200) || num == 0)
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
