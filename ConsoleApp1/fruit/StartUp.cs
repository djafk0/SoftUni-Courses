using System;

namespace fruit
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();

            if (user == "banana" || user == "apple" || user == "kiwi" || user == "cherry" || user == "lemon" ||  user == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (user == "tomato" || user == "cucumber" || user == "pepper" || user == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
