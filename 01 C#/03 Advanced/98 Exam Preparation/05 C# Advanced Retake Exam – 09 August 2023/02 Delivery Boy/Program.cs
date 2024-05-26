using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[dimensions[0], dimensions[1]];

            int deliveryRow = 0;
            int deliveryCol = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        deliveryRow = row;
                        deliveryCol = col;
                    }
                }
            }

            int startingRow = deliveryRow;
            int startingCol = deliveryCol;

            bool gameOver = false;
            bool jackpot = false;

            string command = null;

            while (true)
            {
                string direction = Console.ReadLine();

                int previousRow = deliveryRow;
                int previousCol = deliveryCol;

                if (direction == "up")
                {
                    deliveryRow--;
                }
                else if (direction == "down")
                {
                    deliveryRow++;
                }
                else if (direction == "left")
                {
                    deliveryCol--;
                }
                else if (direction == "right")
                {
                    deliveryCol++;
                }

                if (!ValidIndex(field, deliveryRow, deliveryCol))
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    field[startingRow, startingCol] = ' ';
                    PrintField(field);
                    return;
                }

                if (field[deliveryRow, deliveryCol] == '*')
                {
                    deliveryRow = previousRow;
                    deliveryCol = previousCol;
                    continue;
                }

                char currentChar = field[deliveryRow, deliveryCol];

                if (currentChar == '-')
                {
                    field[deliveryRow, deliveryCol] = '.';
                }
                else if (currentChar == 'P')
                {
                    field[deliveryRow, deliveryCol] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if (currentChar == 'A')
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    field[deliveryRow, deliveryCol] = 'P';
                    PrintField(field);
                    return;
                }

            }
        }

        private static void PrintField(char[,] field)
        {
            for(int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool ValidIndex(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}