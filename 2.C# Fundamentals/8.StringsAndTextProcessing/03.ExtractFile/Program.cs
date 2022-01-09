using System;
using System.Linq;

namespace _3.__Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int backslash = input.LastIndexOf('\\');
            int point = input.LastIndexOf('.');

            string fileName = input.Remove(0, backslash + 1 - (point - backslash));
            int ndpoint = fileName.LastIndexOf('.');
            fileName = fileName.Remove(ndpoint);
            
            string extension = input.Remove(0, point + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}
