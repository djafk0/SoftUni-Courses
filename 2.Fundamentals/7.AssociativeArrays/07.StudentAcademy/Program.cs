using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.__Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double> { });
                }
                grades[name].Add(grade);
            }
            foreach (var item in grades.OrderByDescending(x=>x.Value.Average()))
            {
                if (item.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }
        }
    }
}
