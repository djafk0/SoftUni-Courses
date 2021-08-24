using System;

namespace invalid
{
    class StartUp
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
