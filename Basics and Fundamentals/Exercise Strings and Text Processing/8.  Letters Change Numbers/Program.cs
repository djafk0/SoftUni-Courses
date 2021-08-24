using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _8.__Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] upperCase = new char[26]
            {
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G',
                'H',
                'I',
                'J',
                'K',
                'L',
                'M',
                'N',
                'O',
                'P',
                'Q',
                'R',
                'S',
                'T',
                'U',
                'V',
                'W',
                'X',
                'Y',
                'Z',
            };
            char[] lowerCase = new char[26]
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
            };

            int counter = 0;
            StringBuilder sb = new StringBuilder();
            Dictionary<int, double> output = new Dictionary<int, double>();
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in input)
            {
                sb.Remove(0, sb.Length);
                for (int i = 1; i < item.Length - 1; i++)
                {
                    sb.Append(item[i]);
                }
                double result = double.Parse(sb.ToString());
                double value = 0;
                if (char.IsUpper(item[0]))
                {
                    for (int i = 0; i < upperCase.Length; i++)
                    {
                        if (item[0] == upperCase[i])
                        {
                            value = i + 1;
                            break;
                        }
                    }
                    result /= value;
                }
                else
                {
                    for (int i = 0; i < lowerCase.Length; i++)
                    {
                        if (item[0] == lowerCase[i])
                        {
                            value = i + 1;
                            break;
                        }
                    }
                    result *= value;
                }
                if (char.IsUpper(item[item.Length - 1]))
                {
                    for (int i = 0; i < upperCase.Length; i++)
                    {
                        if (item[item.Length - 1] == upperCase[i])
                        {
                            value = i + 1;
                            break;
                        }
                    }
                    result -= value;
                    output.Add(counter, result);
                    counter++;
                }
                else
                {
                    for (int i = 0; i < lowerCase.Length; i++)
                    {
                        if (item[item.Length - 1] == lowerCase[i])
                        {
                            value = i + 1;
                            break;
                        }
                    }
                    result += value;
                    output.Add(counter, result);
                    counter++;
                }
            }
            Console.WriteLine($"{output.Values.Sum():f2}");
        }
    }
}
