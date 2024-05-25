using System;

namespace ConsoleApp
{
    public class Program
    {
        static char[,] maze;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            maze = new char[n, n];

            int playersRow = 0;
            int playersCol = 0;
            int playersHealth = 100;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    maze[row, col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        playersRow = row;
                        playersCol = col;
                    }
                }
            }

            bool gameOver = false;

            while (!gameOver)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    if (!ValidIndex(playersRow - 1, playersCol))
                    {
                        continue;
                    }

                    maze[playersRow--, playersCol] = '-';
                }
                else if (direction == "down")
                {
                    if (!ValidIndex(playersRow + 1, playersCol))
                    {
                        continue;
                    }

                    maze[playersRow++, playersCol] = '-';
                }
                else if (direction == "left")
                {
                    if (!ValidIndex(playersRow, playersCol - 1))
                    {
                        continue;
                    }

                    maze[playersRow, playersCol--] = '-';
                }
                else if (direction == "right")
                {
                    if (!ValidIndex(playersRow, playersCol + 1))
                    {
                        continue;
                    }

                    maze[playersRow, playersCol++] = '-';
                }

                char currentChar = maze[playersRow, playersCol];

                if (currentChar == 'M')
                {
                    playersHealth -= 40;

                    if (playersHealth <= 0)
                    {
                        gameOver = true;
                    }
                }
                else if (currentChar == 'H')
                {
                    playersHealth += 15;

                    if (playersHealth > 100)
                    {
                        playersHealth = 100;
                    }        
                }
                else if (currentChar == 'X')
                {
                    gameOver = true;
                }

                maze[playersRow, playersCol] = 'P';
            }

            if (playersHealth > 0)
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");               
            }
            else
            {
                Console.WriteLine("Player is dead. Maze over!");

                playersHealth = 0;
            }

            Console.WriteLine($"Player's health: {playersHealth} units");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(maze[row,col]);
                }

                Console.WriteLine();
            }
        }

        private static bool ValidIndex(int row, int col)
        {
            return row >= 0 && row < maze.GetLength(0) && col >= 0 && col < maze.GetLength(1);
        }
    }
}