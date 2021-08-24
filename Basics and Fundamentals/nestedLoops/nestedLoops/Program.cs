using System;

namespace nestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            string film = Console.ReadLine();
            double freePlaces = double.Parse(Console.ReadLine());
            double counter = 0;
            string type = "";
            double standard = 0;
            double kid = 0;
            double student = 0;
            double percent = 0;

            for (int i = 0; i < int.MaxValue; i++)
            {
                counter = 0;
                for (int j = 0; j < freePlaces; j++)
                {
                    type = Console.ReadLine();
                    if (type == "End")
                    {
                        break;
                    }
                    else if (type == "standard")
                    {
                        standard++;
                    }
                    else if (type == "kid")
                    {
                        kid++;
                    }
                    else if (type == "student")
                    {
                        student++;
                    }
                    counter++;
                }
                percent = counter / freePlaces * 100;
                Console.WriteLine($"{film} - {percent:f2}% full.");
                film = Console.ReadLine();
                if (film == "Finish")
                {
                    break;
                }
                freePlaces = int.Parse(Console.ReadLine());
                
            }
            double totalTickets = standard + kid + student;
            Console.WriteLine($"Total tickets: {totalTickets}");
            double studentPercent = student / totalTickets * 100;
            Console.WriteLine($"{studentPercent:f2}% student tickets.");
            double standartPercent = standard / totalTickets * 100;
            Console.WriteLine($"{standartPercent:f2}% standard tickets.");
            double kidPercent = kid / totalTickets * 100;
            Console.WriteLine($"{kidPercent:f2}% kids tickets.");
        }
    }
}