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

        // ASCII const
        const int ASCII_START = 33;
        const int ASCII_END = 126;

        // Display Choices
        const int MODE_NUMBERED = 1;
        const int MODE_COORDINATE = 2;
        const int MODE_CHESSBOARD = 3;
        const int MODE_HIGHLIGHT_GRID = 4;

        // Grid Symbols
        const char SYMBOL_CHESSBOARD_X = 'X';
        const char SYMBOL_CHESSBOARD_O = 'O';
        const char SYMBOL_BORDER = '#';
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dynamic Grid");

            int row, col;

            while (true)
            {
                Console.WriteLine("Enter the number of rows");
                if (int.TryParse(Console.ReadLine(), out row) && row > 0) // Converts input into integer and make sure it is greater than 0
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{INVALID_INPUT}! Please enter a positive number for row");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter the number of columns");
                if (int.TryParse(Console.ReadLine(), out col) && col > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{INVALID_INPUT}! Please enter a positive number for column");
                }
            }


            char[,] grid = new char[row, col];

            Console.WriteLine($"How would you like to fill the grid? {CHOICE_RANDOM} or {CHOICE_CUSTOM}? ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == CHOICE_RANDOM )
            {
                Random rng = new Random();
                for (int i = 0; i < row;  i++)
                {
                    for (int j = 0; j < col; j++)
                        grid[i, j] = (char)rng.Next(ASCII_START, ASCII_END); // Randomly select ASCII symbols
                }
            }
            else if(choice.ToLower() == CHOICE_CUSTOM )
            {
                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; j++)
                    {
                        char inputChar;
                        while(true) // Loops until valid input
                        {
                            Console.WriteLine($"Enter a character for cell {i}, {j}:");
                            string input = Console.ReadLine();

                            if (!string.IsNullOrEmpty(input) && input.Length == 1)
                            {
                                inputChar = input[0];
                                break;
                            }

                            Console.WriteLine($"{INVALID_INPUT}! Try again");

                        }

                        grid[i, j] = inputChar;
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

            int mode = Convert.ToInt32(Console.ReadLine());

            switch (mode)
            {
                case MODE_NUMBERED:
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

                case MODE_COORDINATE:
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

                case MODE_CHESSBOARD:
                    for (int i = 0; i < row;i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if ((i + j) % 2 == 0) // If the number is divisible by 2
                            {
                                grid[i, j] = SYMBOL_CHESSBOARD_X;
                            }
                            else
                            {
                                grid[i, j] = SYMBOL_CHESSBOARD_O;
                            }
                            Console.Write(grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    break;

                case MODE_HIGHLIGHT_GRID:
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if (i == 0 || i == row -1 || j == 0 || j == col -1) // Boarder position
                            {
                                grid[i, j] = SYMBOL_BORDER;
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
