using System;

namespace ontime
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minutesOfArrival = int.Parse(Console.ReadLine());



            double examInMinutes = hourOfExam * 60 + minutesOfExam;
            double arrivalInMinutes = hourOfArrival * 60 + minutesOfArrival;

            double finalMinutes = Math.Abs(examInMinutes - arrivalInMinutes);
            double finalHour = Math.Floor(finalMinutes / 60);

            string resultMinutes = finalMinutes % 60 < 10 ? string.Format($"0{finalMinutes % 60}") : (finalMinutes % 60).ToString();

            if (arrivalInMinutes > examInMinutes)
            {
                Console.WriteLine("late");
                if (finalMinutes < 60)
                {
                    Console.WriteLine($"{finalMinutes} minutes after the start");
                }

                else
                {
                    Console.WriteLine($"{finalHour}:{resultMinutes} hours after the start");
                }

            }
            else if (examInMinutes == arrivalInMinutes)
            {
                Console.WriteLine("on time");

            }
            else if (examInMinutes - 30 <= arrivalInMinutes && examInMinutes - 1 >= arrivalInMinutes)
            {

                Console.WriteLine($"on time {finalMinutes} minutes before the start");
            }
            else
            {
                Console.WriteLine("Early");

                if (finalMinutes < 60)
                {
                    Console.WriteLine($"{finalMinutes} minutes before the start");
                }

                else
                {
                    Console.WriteLine($"{finalHour}:{resultMinutes} hours before the start");
                }
            }
        }
    }
}
