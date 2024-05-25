using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] fishingArea = new char[n, n];

            int shipRow = 0;
            int shipCol = 0;

            int quantity = 0;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    fishingArea[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }
                }
            }

            string command = null;

            while ((command = Console.ReadLine()) != "collect the nets")
            {
                string direction = command;

                int previousRow = shipRow;
                int previousCol = shipCol;

                if (direction == "up")
                {
                    shipRow--;
                }
                else if (direction == "down")
                {
                    shipRow++;
                }
                else if (direction == "left")
                {
                    shipCol--;
                }
                else if (direction == "right")
                {
                    shipCol++;
                }

                var cordinates = AdjustCordinates(fishingArea, shipRow, shipCol);

                shipRow = cordinates[0];
                shipCol = cordinates[1];

                fishingArea[previousRow, previousCol] = '-';

                char currentChar = fishingArea[shipRow, shipCol];

                if (currentChar == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRow},{shipCol}]");
                    return;
                }

                if (char.IsDigit(currentChar))
                {
                    quantity += currentChar - 48;
                }

                fishingArea[shipRow, shipCol] = 'S';
            }

            if (quantity >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - quantity} tons of fish more.");
            }

            if (quantity > 0)
            {
                Console.WriteLine($"Amount of fish caught: {quantity} tons.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(fishingArea[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int[] AdjustCordinates(char[,] fishingArea, int row, int col)
        {
            int[] arr = { row, col };

            if (row == -1)
            {
                arr[0] = fishingArea.GetLength(0) - 1;
            }
            if (row == fishingArea.GetLength(0))
            {
                arr[0] = 0;
            }
            if (col == -1)
            {
                arr[1] = fishingArea.GetLength(1) - 1;
            }
            if (col == fishingArea.GetLength(1))
            {
                arr[1] = 0;
            }

            return arr;
        }
    }
}