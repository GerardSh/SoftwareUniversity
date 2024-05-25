using System;

namespace ConsoleApp
{
    public class Program
    {
        public static char[,] board;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            board = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            int amount = 100;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    board[row, col] = currentRow[col];

                    if (currentRow[col] == 'G')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool gameOver = false;
            bool jackpot = false;

            string command = null;

            while ((command = Console.ReadLine()) != "end" && !gameOver)
            {
                string direction = command;

                int previousRow = playerRow;
                int previousCol = playerCol;

                if (direction == "up")
                {
                    playerRow--;
                }
                else if (direction == "down")
                {
                    playerRow++;
                }
                else if (direction == "left")
                {
                    playerCol--;
                }
                else if (direction == "right")
                {
                    playerCol++;
                }

                if (!ValidIndex(playerRow, playerCol))
                {
                    Console.WriteLine("Game over! You lost everything!");
                    return;
                }

                board[previousRow, previousCol] = '-';

                char currentChar = board[playerRow, playerCol];

                if (currentChar == 'W')
                {
                    amount += 100;
                }
                else if (currentChar == 'P')
                {
                    amount -= 200;

                    if (amount <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }
                else if (currentChar == 'J')
                {
                    amount += 100_000;
                    gameOver = true;
                    jackpot = true;
                }

                board[playerRow, playerCol] = 'G';
            }

            if (jackpot)
            {
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game.Total amount: {amount}$");
            }
            else
            {
                Console.WriteLine($"End of the game. Total amount: {amount}$");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(board[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool ValidIndex(int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}