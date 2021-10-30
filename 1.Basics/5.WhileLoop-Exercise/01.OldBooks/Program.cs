using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string search = Console.ReadLine();
            int counter = 0;
            bool flag = false;

            while (search != "No More Books")
            {
                if (search == book)
                {
                    flag = true;
                    break;
                }

                counter++;
                search = Console.ReadLine();
            }

            if (flag)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
