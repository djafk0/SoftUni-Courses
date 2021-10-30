using System;

namespace _01.ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "Stop")
                {
                    break;
                }
                Console.WriteLine(name);
            }
        }
    }
}
