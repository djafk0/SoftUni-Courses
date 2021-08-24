using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour1 = int.Parse(Console.ReadLine());
            int minutes1 = int.Parse(Console.ReadLine());
            int hour2 = int.Parse(Console.ReadLine());
            int minutes2 = int.Parse(Console.ReadLine());

            int examMinutes = hour1 * 60 + minutes1;
            int arriveMinutes = hour2 * 60 + minutes2;

            if (arriveMinutes > examMinutes)
            {
                Console.WriteLine("Late");
                int lateInMinutes = arriveMinutes - examMinutes;
                if (lateInMinutes < 60)
                {
                    Console.WriteLine($"{lateInMinutes} minutes after the start");
                }
                else
                {
                    int lateHour = lateInMinutes / 60;
                    int lateMinutes = lateInMinutes % 60;
                    Console.WriteLine($"{lateHour}:{lateMinutes:D2} hours after the start");
                }
            }
            else if (arriveMinutes == examMinutes || examMinutes - arriveMinutes <= 30)
            {
                Console.WriteLine("On time");
                if (arriveMinutes != examMinutes)
                {
                    Console.WriteLine($"{examMinutes - arriveMinutes} minutes before the start");
                }
            }
            else if (examMinutes - arriveMinutes > 30)
            {
                Console.WriteLine("Early");
                int earlyInMinutes = examMinutes - arriveMinutes;
                if (earlyInMinutes < 60)
                {
                    Console.WriteLine($"{earlyInMinutes} minutes before the start");
                }
                else
                {
                    int earlyHour = earlyInMinutes / 60;
                    int earlyMinutes = earlyInMinutes % 60;
                    Console.WriteLine($"{earlyHour}:{earlyMinutes:D2} hours before the start");
                }
            }
        }
    }
}
