namespace ConsoleApp
{
    public class Program
    {
        static int vankoRow = -1;
        static int vankoCol = -1;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = currentRow[col];

                    if (currentRow[col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            bool drilledAllHoles = true;
            string command;
            int countOfHoles = 1;
            int countOfRods = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                if (OutsideBoundaries(wall, command))
                {
                    continue;
                }

                wall[vankoRow, vankoCol] = '*';

                int previousRow = vankoRow;
                int previousCOl = vankoCol;

                ChangePosition(command);

                if (wall[vankoRow, vankoCol] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");

                    vankoRow = previousRow;
                    vankoCol = previousCOl;

                    countOfRods++;
                }
                else if (wall[vankoRow, vankoCol] == 'C')
                {
                    wall[vankoRow, vankoCol] = 'E';
                    countOfHoles++;
                    drilledAllHoles = false;

                    break;
                }
                else if (wall[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }
                else
                {
                    countOfHoles++;
                }

                wall[vankoRow, vankoCol] = 'V';
            }

            if (drilledAllHoles)
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void ChangePosition(string command)
        {
            if (command == "up")
            {
                vankoRow--;
            }
            else if (command == "down")
            {
                vankoRow++;
            }
            else if (command == "left")
            {
                vankoCol--;
            }
            else if (command == "right")
            {
                vankoCol++;
            }
        }

        private static bool OutsideBoundaries(char[,] territory, string command)
        {
            if (command == "up" && vankoRow == 0
                || command == "down" && vankoRow == territory.GetLength(0) - 1
                || command == "left" && vankoCol == 0
                || command == "right" && vankoCol == territory.GetLength(1) - 1)
            {
                return true;
            }

            return false;
        }
    }
}