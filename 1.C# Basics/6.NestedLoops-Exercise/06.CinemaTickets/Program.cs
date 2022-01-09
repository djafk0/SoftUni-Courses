using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double countTickets = 0;
            int allTickets = 0;
            double countStandartTicket = 0;
            double countStudentTicket = 0;
            double countKidTicket = 0;
            int freeOnesPlaces = 0;
            string movieName = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }
                else
                {
                    movieName = input;
                    freeOnesPlaces = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= freeOnesPlaces; i++)
                    {
                        string ticketType = Console.ReadLine();

                        if (ticketType == "End")
                        {
                            Console.WriteLine($"{movieName} - {(countTickets / freeOnesPlaces) * 100:f2}% full.");
                            countTickets = 0;
                            break;
                        }
                        else
                        {
                            countTickets++;
                            allTickets++;
                            if (ticketType == "student")
                            {
                                countStudentTicket++;
                            }
                            else if (ticketType == "standard")
                            {
                                countStandartTicket++;
                            }
                            else if (ticketType == "kid")
                            {
                                countKidTicket++;
                            }
                        }

                        if (i == freeOnesPlaces)
                        {
                            Console.WriteLine($"{movieName} - {((countTickets / freeOnesPlaces) * 100):f2}% full.");
                            countTickets = 0;
                        }
                    }
                }
            }

            Console.WriteLine($"Total tickets: {allTickets}");
            Console.WriteLine($"{((countStudentTicket / allTickets) * 100):f2}% student tickets.");
            Console.WriteLine($"{((countStandartTicket / allTickets) * 100):f2}% standard tickets.");
            Console.WriteLine($"{((countKidTicket / allTickets) * 100):f2}% kids tickets.");
        }
    }
}
