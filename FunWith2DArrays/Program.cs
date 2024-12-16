﻿using System.Diagnostics.Metrics;

namespace FunWith2DArrays
{
    internal class Program
    {

        const string CHOICE_RANDOM = "random";
        const string CHOICE_CUSTOM = "custom";
        const string CHOICE_CHESSBOARD = "chessboard";
        const string CHOICE_HIGHLIGHT_GRID = "highlight grid";
        const string CHOICE_NUMBERED = "numbered";
        const string CHOICE_COORDINATE = "coordinate";
        const string INVALID_INPUT = "Invalid Input";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dynamic Grid");

            Console.WriteLine("Enter the number of rows:");
            int row = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns:");
            int col = int.Parse(Console.ReadLine());

            char[,] grid = new char[row, col];

            Console.WriteLine($"How would you like to fill the grid? {CHOICE_RANDOM} or {CHOICE_CUSTOM}? ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == CHOICE_RANDOM )
            {
                Random rng = new Random();
                for (int i = 0; i < row;  i++)
                {
                    for (int j = 0; j < col; j++)
                        grid[i, j] = (char)rng.Next(33, 126); // Randomly select ASCII symbols
                }
            }
            else if(choice.ToLower() == CHOICE_CUSTOM )
            {
                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.WriteLine($"Enter a value for cell {i},{j}");
                        grid[i, j] = Console.ReadLine()[0];
                    }
                }
            }
            else
            {
                Console.WriteLine(INVALID_INPUT);
                return;
            }

            Console.WriteLine("Printing grid...");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Choose a display style by enter a number:");
            Console.WriteLine($"1: {CHOICE_NUMBERED}");
            Console.WriteLine($"2: {CHOICE_COORDINATE}");
            Console.WriteLine($"3: {CHOICE_CHESSBOARD}");
            Console.WriteLine($"4: {CHOICE_HIGHLIGHT_GRID}");

            int displayChoice = Convert.ToInt32(Console.ReadLine());

            switch (displayChoice)
            {
                case 1:
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            Console.Write("+---"); // Each col gets a '+---'
                        }
                        Console.WriteLine("+"); // End of row

                        for (int j = 0; j < col; j++)
                        {
                            Console.Write($"| {grid[i, j]} "); // '|' next to each value
                        }
                        Console.WriteLine("|"); // End of the grid row
                    }

                    for (int j = 0; j < col; j++)
                    {
                        Console.Write("+---"); // Final bottom border
                    }
                    Console.WriteLine("+");

                    break;

                case 2:
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col;j++)
                        {
                            Console.Write("+---");
                        }
                        Console.WriteLine("+");

                        for (int j = 0;j < col;j++)
                        {
                            Console.Write($"|{i},{j}");
                        }
                        Console.WriteLine("|");
                        
                    }
                    
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write("+---");
                    }
                    Console.WriteLine("+");

                    break;

                case 3:
                    for (int i = 0; i < row;i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if ((i + j) % 2 == 0) // If the number is divisible by 2
                            {
                                grid[i, j] = 'X';
                            }
                            else
                            {
                                grid[i, j] = 'O';
                            }
                            Console.Write(grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    break;

                case 4:
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if (i == 0 || i == row -1 || j == 0 || j == col -1) // Boarder position
                            {
                                grid[i, j] = '#';
                            }
                            Console.Write(grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    break;

                default:
                    Console.WriteLine(INVALID_INPUT);
                    break;
            }

        }
    }
}