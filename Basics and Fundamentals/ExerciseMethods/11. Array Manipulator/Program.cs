using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);
                    if (arr.Length <= index || index < 0)
                    {
                        Console.WriteLine($"Invalid index");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    for (int i = 0; i <= index; i++)
                    {
                        int savedNumber = arr[0];
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (j < arr.Length - 1)
                            {
                                arr[j] = arr[j + 1];
                            }
                        }
                        arr[arr.Length - 1] = savedNumber;
                    }
                }

                else if (command[0] == "max")
                {
                    int maxNumber = int.MinValue;
                    int currentIndex = 0;
                    int currentNumber = 0;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        currentNumber = arr[i];
                        if (command[1] == "even" && arr[i] % 2 == 0 && maxNumber <= currentNumber)
                        {
                            currentIndex = i;
                            maxNumber = currentNumber;
                        }
                        else if (command[1] == "odd" && arr[i] % 2 == 1 && maxNumber <= currentNumber)
                        {
                            currentIndex = i;
                            maxNumber = currentNumber;
                        }

                    }
                    if (command[0] == "max" && command[1] == "even" && maxNumber == -2147483648)
                    {
                        Console.WriteLine("No matches");
                    }
                    else if (command[0] == "max" && command[1] == "odd" && maxNumber == -2147483648)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(currentIndex);
                    }
                }
                else if (command[0] == "min")
                {
                    int minNumber = int.MaxValue;
                    int currentIndex = 0;
                    int currentNumber = 0;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        currentNumber = arr[i];
                        if (command[1] == "even" && arr[i] % 2 == 0 && minNumber >= currentNumber)
                        {
                            currentIndex = i;
                            minNumber = currentNumber;
                        }
                        else if (command[1] == "odd" && arr[i] % 2 == 1 && minNumber >= currentNumber)
                        {
                            currentIndex = i;
                            minNumber = currentNumber;
                        }
                    }
                    if (command[0] == "min" && command[1] == "odd" && minNumber == 2147483647)
                    {
                        Console.WriteLine("No matches");
                    }
                    else if (command[0] == "min" && command[1] == "even" && minNumber == 2147483647)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(currentIndex);
                    }
                }
                bool isOneOrMore = false;
                if (command[0] == "first" && command[2] == "even")
                {
                    int i = 0;
                    int evenOrOddCounter = 0;
                    int checker = 0;
                    int counter = 0;
                    int count = int.Parse(command[1]);
                    int[] firstEven = new int[count];
                    if (count >= arr.Length + 1)
                    {
                        Console.WriteLine($"Invalid count");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    for (i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            evenOrOddCounter++;
                        }
                    }
                    int[] notEnought = new int[evenOrOddCounter];
                    for (i = 0; i < arr.Length; i++)
                    {
                        int currentNumber = arr[i];

                        if (currentNumber % 2 == 0)
                        {
                            isOneOrMore = true;
                            firstEven[counter] = currentNumber;
                            notEnought[counter] = currentNumber;
                            counter++;
                            checker++;
                            if (checker == count)
                            {
                                Console.WriteLine($"[{string.Join(", ", firstEven)}]");
                                break;
                            }
                        }
                    }

                    if (!isOneOrMore)
                    {
                        Console.WriteLine("[]");
                    }
                    else if (i == arr.Length)
                    {
                        Console.WriteLine($"[{string.Join(", ", notEnought)}]");
                    }
                }
                else if (command[0] == "first" && command[2] == "odd")
                {
                    int i = 0;
                    int evenOrOddCounter = 0;
                    int checker = 0;
                    int counter = 0;
                    int count = int.Parse(command[1]);
                    int[] firstEven = new int[count];
                    if (count >= arr.Length + 1)
                    {
                        Console.WriteLine($"Invalid count");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    for (i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 1)
                        {
                            evenOrOddCounter++;
                        }
                    }
                    int[] notEnought = new int[evenOrOddCounter];
                    for (i = 0; i < arr.Length; i++)
                    {
                        int currentNumber = arr[i];

                        if (currentNumber % 2 == 1)
                        {
                            isOneOrMore = true;
                            firstEven[counter] = currentNumber;
                            notEnought[counter] = currentNumber;
                            counter++;
                            checker++;
                            if (checker == count)
                            {
                                Console.WriteLine($"[{string.Join(", ", firstEven)}]");
                                break;
                            }
                        }
                    }
                    if (!isOneOrMore)
                    {
                        Console.WriteLine("[]");
                    }
                    else if (i == arr.Length)
                    {
                        Console.WriteLine($"[{string.Join(", ", notEnought)}]");
                    }
                }
                else if (command[0] == "last" && command[2] == "even")
                {
                    int i = 0;
                    int evenOrOddCounter = 0;
                    int checker = 0;
                    int count = int.Parse(command[1]);
                    int counter = count; 
                    int[] firstEven = new int[count];
                    if (count >= arr.Length + 1)
                    {
                        Console.WriteLine($"Invalid count");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    for (i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            evenOrOddCounter++;
                        }
                    }
                    int[] notEnought = new int[evenOrOddCounter];
                    for (i = arr.Length - 1; i >= 0; i--)
                    {
                        int currentNumber = arr[i];

                        if (currentNumber % 2 == 0)
                        {
                            if (evenOrOddCounter < count)
                            {
                                notEnought[evenOrOddCounter - checker - 1] = currentNumber;
                            }
                            isOneOrMore = true;
                            firstEven[counter - 1] = currentNumber;
                            counter--;
                            checker++;
                            if (checker == count)
                            {
                                Console.WriteLine($"[{string.Join(", ", firstEven)}]");
                                break;
                            }
                        }
                    }
                    if (!isOneOrMore)
                    {
                        Console.WriteLine("[]");
                    }
                    else if (i == -1)
                    {
                        Console.WriteLine($"[{string.Join(", ", notEnought)}]");
                    }
                }
                else if (command[0] == "last" && command[2] == "odd")
                {
                    int i = 0;
                    int evenOrOddCounter = 0;
                    int checker = 0;
                    int count = int.Parse(command[1]);
                    int counter = count;
                    int[] firstEven = new int[count];
                    if (count >= arr.Length + 1)
                    {
                        Console.WriteLine($"Invalid count");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    for (i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 1)
                        {
                            evenOrOddCounter++;
                        }
                    }
                    int[] notEnought = new int[evenOrOddCounter];
                    for (i = arr.Length - 1; i >= 0; i--)
                    {
                        int currentNumber = arr[i];

                        if (currentNumber % 2 == 1)
                        {
                            if (evenOrOddCounter < count)
                            {
                            notEnought[evenOrOddCounter - checker - 1] = currentNumber;
                            }

                            firstEven[counter - 1] = currentNumber;
                            isOneOrMore = true;
                            counter--;
                            checker++;
                            if (checker == count)
                            {
                                Console.WriteLine($"[{string.Join(", ", firstEven)}]");
                                break;
                            }
                        }
                    }
                    if (!isOneOrMore)
                    {
                        Console.WriteLine("[]");
                    }
                    else if (i == -1)
                    {
                        Console.WriteLine($"[{string.Join(", ", notEnought)}]");
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");

        }
    }
}
