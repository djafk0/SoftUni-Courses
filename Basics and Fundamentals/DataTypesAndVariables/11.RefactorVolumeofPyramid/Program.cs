using System;

namespace _11.RefactorVolumeofPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double dul, sh, V, volume = 0;
            Console.Write("Length: ");
            dul = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            sh = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            V = double.Parse(Console.ReadLine());
            volume = (dul * sh * V) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
