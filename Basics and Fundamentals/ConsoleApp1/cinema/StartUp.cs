using System;

namespace cinema
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();

            //Monday	Tuesday	Wednesday	Thursday	Friday	Saturday	Sunday
            //12  12  14  14  12  16  16

            if (day == "Monday" || day == "Tuesday" || day == "Friday")
            {
                Console.WriteLine("12");
            }
            else if (day == "Wednesday" || day == "Thursday")
            {
                Console.WriteLine("14");
            }
            else
            {
                Console.WriteLine("16");
            }
        }
    }
}
