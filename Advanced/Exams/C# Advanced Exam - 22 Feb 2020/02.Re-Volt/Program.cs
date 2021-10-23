using System;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int rowPosition = 0;
            int colPosition = 0;

            for (int i = 0; i < n; i++)
            {
                char[] array = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = array[j];

                    if (matrix[i, j] == 'f')
                    {
                        rowPosition = i;
                        colPosition = j;
                    }
                }
            }

            for (int k = 0; k < m; k++)
            {
                string command = Console.ReadLine();
                matrix[rowPosition, colPosition] = '-';

                rowPosition = RowMoving(rowPosition, command);
                colPosition = ColMoving(colPosition, command);
                IsItInsideTheBounds(n, ref rowPosition, ref colPosition);

                if (matrix[rowPosition, colPosition] == 'B')
                {
                    rowPosition = RowMoving(rowPosition, command);
                    colPosition = ColMoving(colPosition, command);
                    IsItInsideTheBounds(n, ref rowPosition, ref colPosition);
                }
                else if (matrix[rowPosition, colPosition] == 'T')
                {
                    rowPosition = RowTrapMoving(rowPosition, command);
                    colPosition = ColTrapMoving(colPosition, command);
                }

                if (matrix[rowPosition, colPosition] == 'F')
                {
                    matrix[rowPosition, colPosition] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(n, matrix);

                    return;
                }

                matrix[rowPosition, colPosition] = 'f';
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(n, matrix);
        }

        private static void IsItInsideTheBounds(int n, ref int rowPosition, ref int colPosition)
        {
            if (rowPosition < 0)
            {
                rowPosition = n - 1;
            }
            else if (rowPosition > n - 1)
            {
                rowPosition = 0;
            }
            else if (colPosition < 0)
            {
                colPosition = n - 1;
            }
            else if (colPosition > n - 1)
            {
                colPosition = 0;
            }
        }

        private static void PrintMatrix(int n, char[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static int RowTrapMoving(int rowPosition, string command)
        {
            if (command == "up")
            {
                rowPosition++;
            }
            else if (command == "down")
            {
                rowPosition--;
            }

            return rowPosition;
        }

        private static int ColTrapMoving(int colPosition, string command)
        {
            if (command == "left")
            {
                colPosition++;
            }
            else if (command == "right")
            {
                colPosition--;
            }

            return colPosition;
        }

        private static int ColMoving(int colPosition, string command)
        {
            if (command == "left")
            {
                colPosition--;
            }
            else if (command == "right")
            {
                colPosition++;
            }

            return colPosition;
        }

        private static int RowMoving(int rowPosition, string command)
        {
            if (command == "up")
            {
                rowPosition--;
            }
            else if (command == "down")
            {
                rowPosition++;
            }

            return rowPosition;
        }
    }
}
