using System;
using System.Linq;
using System.Numerics;

namespace P02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vankoPosRow = 0;
            int vankoPosCol = 0;
            int countHoles = 1;
            int countRods = 0;
            bool isElectrocuted = true;

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            FillMatrix();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End" && isElectrocuted)
            {
                if (command == "up")
                {
                    MoveTo(vankoPosRow - 1, vankoPosCol);
                }
                else if (command == "down")
                {

                    MoveTo(vankoPosRow + 1, vankoPosCol);
                }
                else if (command == "left")
                {

                    MoveTo(vankoPosRow, vankoPosCol - 1);
                }
                else if (command == "right")
                {

                    MoveTo(vankoPosRow, vankoPosCol + 1);
                }
            }

            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                PrintMatrix();
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRods} rod(s).");
                PrintMatrix();
            }




            void FillMatrix()
            {
                for (int rows = 0; rows < n; rows++)
                {
                    var row = Console.ReadLine().ToArray();
                    for (int cols = 0; cols < n; cols++)
                    {
                        matrix[rows, cols] = row[cols];
                        if (matrix[rows, cols] == 'V')
                        {
                            vankoPosRow = rows;
                            vankoPosCol = cols;
                        }
                    }

                }
            }

            void MoveTo(int newRow, int newCol)
            {
                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n)
                {
                    if (matrix[newRow, newCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{newRow}, {newCol}]!");
                        matrix[newRow, newCol] = 'V';
                        matrix[vankoPosRow, vankoPosCol] = '*';
                        vankoPosRow = newRow;
                        vankoPosCol = newCol;
                    }

                    else if (matrix[newRow, newCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        countRods++;
                    }
                    else if (matrix[newRow, newCol] == 'C')
                    {
                        matrix[newRow, newCol] = 'E';
                        matrix[vankoPosRow, vankoPosCol] = '*';
                        countHoles++;
                        isElectrocuted = false;
                    }
                    else
                    {
                        countHoles++;
                        matrix[newRow, newCol] = 'V';
                        matrix[vankoPosRow, vankoPosCol] = '*';
                        vankoPosRow = newRow;
                        vankoPosCol = newCol;
                    }
                }
            }


            void PrintMatrix()
            {
                for (int rows = 0; rows < n; rows++)
                {

                    for (int cols = 0; cols < n; cols++)
                    {
                        Console.Write(matrix[rows, cols]);
                    }
                    Console.WriteLine();
                }
            }

        }

    }
}