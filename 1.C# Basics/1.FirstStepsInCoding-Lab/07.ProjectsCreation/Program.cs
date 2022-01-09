using System;

namespace _07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTheArchitect = Console.ReadLine();
            int countOfProjects = int.Parse(Console.ReadLine());
            int timeNeedForProjects = countOfProjects * 3;
            Console.WriteLine($"The architect {nameOfTheArchitect} will need {timeNeedForProjects} hours to complete {countOfProjects} project/s.");
        }
    }
}
