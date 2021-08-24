using System;

namespace working
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double time = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if (time >= 10 && time <= 18)
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday")
                {
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("closed");
                }

            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
