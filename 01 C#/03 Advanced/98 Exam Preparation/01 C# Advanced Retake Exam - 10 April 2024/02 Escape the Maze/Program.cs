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

            int playerRow = 0;
            int playerCol = 0;
            int playerHealth = 100;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    maze[row, col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool gameOver = false;

            while (!gameOver)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    if (!ValidIndex(playerRow - 1, playerCol))
                    {
                        continue;
                    }

                    maze[playerRow--, playerCol] = '-';
                }
                else if (direction == "down")
                {
                    if (!ValidIndex(playerRow + 1, playerCol))
                    {
                        continue;
                    }

                    maze[playerRow++, playerCol] = '-';
                }
                else if (direction == "left")
                {
                    if (!ValidIndex(playerRow, playerCol - 1))
                    {
                        continue;
                    }

                    maze[playerRow, playerCol--] = '-';
                }
                else if (direction == "right")
                {
                    if (!ValidIndex(playerRow, playerCol + 1))
                    {
                        continue;
                    }

                    maze[playerRow, playerCol++] = '-';
                }

                char currentChar = maze[playerRow, playerCol];

                if (currentChar == 'M')
                {
                    playerHealth -= 40;

                    if (playerHealth <= 0)
                    {
                        gameOver = true;
                    }
                }
                else if (currentChar == 'H')
                {
                    playerHealth += 15;

                    if (playerHealth > 100)
                    {
                        playerHealth = 100;
                    }        
                }
                else if (currentChar == 'X')
                {
                    gameOver = true;
                }

                maze[playerRow, playerCol] = 'P';
            }

            if (playerHealth > 0)
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");               
            }
            else
            {
                Console.WriteLine("Player is dead. Maze over!");

                playerHealth = 0;
            }

            Console.WriteLine($"Player's health: {playerHealth} units");

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