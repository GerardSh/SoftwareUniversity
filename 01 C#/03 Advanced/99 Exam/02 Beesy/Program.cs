//09:12
namespace ConsoleApp
{
    public class Program
    {
        static int beeRow = -1;
        static int beeCol = -1;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int energy = 15;
            int unitsOfNectar = 0;
            bool restoreEnergy = true;
            bool hiveReached = false;

            while (true)
            {
                string command = Console.ReadLine();
                field[beeRow, beeCol] = '-';
                energy--;

                if (command == "up")
                {
                    if (beeRow == 0)
                    {
                        beeRow = field.GetLength(0) - 1;
                    }
                    else
                    {
                        beeRow--;
                    }
                }
                else if (command == "down")
                {
                    if (beeRow == field.GetLength(0) - 1)
                    {
                        beeRow = 0;
                    }
                    else
                    {
                        beeRow++;
                    }
                }
                else if (command == "left")
                {
                    if (beeCol == 0)
                    {
                        beeCol = field.GetLength(1) - 1;
                    }
                    else
                    {
                        beeCol--;
                    }
                }
                else if (command == "right")
                {
                    if (beeCol == field.GetLength(1) - 1)
                    {
                        beeCol = 0;
                    }
                    else
                    {
                        beeCol++;
                    }
                }

                if (char.IsDigit(field[beeRow, beeCol]))
                {
                    unitsOfNectar += field[beeRow, beeCol] - 48;
                }
                else if (field[beeRow, beeCol] == 'H')
                {
                    hiveReached = true;
                    field[beeRow, beeCol] = 'B';
                    break;
                }

                field[beeRow, beeCol] = 'B';

                if (energy == 0)
                {
                    if (restoreEnergy && unitsOfNectar >= 30)
                    {
                        restoreEnergy = false;
                        energy = unitsOfNectar - 30;
                    }

                    if (energy == 0)
                    {
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        break;
                    }
                }
            }

            if (hiveReached && unitsOfNectar >= 30)
            {
                Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
            }
            else if (hiveReached && unitsOfNectar < 30)
            {
                Console.WriteLine("Beesy did not manage to collect enough nectar.");
            }

            PrintMatrix(field);
        }

        private static void PrintMatrix(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
//09:33:14 22.06.2024