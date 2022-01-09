using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int goal = 10_000;

            var isGoingHome = false;
            var totalSteps = 0;
            while (totalSteps < goal && !isGoingHome)
            {
                var input = Console.ReadLine();
                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    isGoingHome = true;
                }

                var currentSteps = int.Parse(input);
                totalSteps += currentSteps;
            }

            if (totalSteps >= goal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - goal} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goal - totalSteps} more steps to reach goal.");
            }
        }
    }
}
