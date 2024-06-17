namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] cupboard = new char[dimensions[0], dimensions[1]];

            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseCount = 0;
            int cheeseEaten = 0;

            for (int row = 0; row < cupboard.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cupboard.GetLength(1); col++)
                {
                    cupboard[row, col] = currentRow[col];

                    if (currentRow[col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }

                    if (currentRow[col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "danger")
            {
                char symbol = ' ';

                bool isOutside = false;

                if (command == "up")
                {
                    if (IsValid(cupboard, mouseRow - 1, mouseCol))
                    {
                        if (cupboard[mouseRow - 1, mouseCol] == '@')
                        {
                            continue;
                        }

                        cupboard[mouseRow, mouseCol] = '*';
                        symbol = cupboard[--mouseRow, mouseCol];
                        cupboard[mouseRow, mouseCol] = 'M';
                    }
                    else
                    {
                        isOutside = true;
                    }
                }
                else if (command == "down")
                {
                    if (IsValid(cupboard, mouseRow + 1, mouseCol))
                    {
                        if (cupboard[mouseRow + 1, mouseCol] == '@')
                        {
                            continue;
                        }
                        cupboard[mouseRow, mouseCol] = '*';
                        symbol = cupboard[++mouseRow, mouseCol];
                        cupboard[mouseRow, mouseCol] = 'M';
                    }
                    else
                    {
                        isOutside = true;
                    }
                }
                else if (command == "left")
                {
                    if (IsValid(cupboard, mouseRow, mouseCol - 1))
                    {
                        if (cupboard[mouseRow, mouseCol - 1] == '@')
                        {
                            continue;
                        }
                        cupboard[mouseRow, mouseCol] = '*';
                        symbol = cupboard[mouseRow, --mouseCol];
                        cupboard[mouseRow, mouseCol] = 'M';
                    }
                    else
                    {
                        isOutside = true;
                    }
                }
                else if (command == "right")
                {
                    if (IsValid(cupboard, mouseRow, mouseCol + 1))
                    {
                        if (cupboard[mouseRow, mouseCol + 1] == '@')
                        {
                            continue;
                        }

                        cupboard[mouseRow, mouseCol] = '*';
                        symbol = cupboard[mouseRow, ++mouseCol];
                        cupboard[mouseRow, mouseCol] = 'M';
                    }
                    else
                    {
                        isOutside = true;
                    }
                }

                if (isOutside)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }

                if (symbol == 'C')
                {
                    cheeseEaten++;
                }
                else if (symbol == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }

                if (cheeseCount == cheeseEaten)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
            }

            if (command == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }

            for (int row = 0; row < cupboard.GetLength(0); row++)
            {
                for (int col = 0; col < cupboard.GetLength(1); col++)
                {
                    Console.Write(cupboard[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsValid(char[,] cupboard, int row, int col) => row >= 0 && row < cupboard.GetLength(0) && col >= 0 && col < cupboard.GetLength(1);
    }
}




//2
namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] cupboard = new char[dimensions[0], dimensions[1]];

            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseCount = 0;
            int cheeseEaten = 0;

            for (int row = 0; row < cupboard.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cupboard.GetLength(1); col++)
                {
                    cupboard[row, col] = currentRow[col];

                    if (currentRow[col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                        cupboard[row, col] = '*';
                    }

                    if (currentRow[col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "danger")
            {
                bool isOutside = false;

                if (command == "left")
                {
                    if (IsOutside(cupboard, mouseRow, mouseCol - 1))
                    {
                        isOutside = true;
                    }
                    else
                    {
                        if (isWall(cupboard, mouseRow, mouseCol - 1))
                        {
                            cupboard[mouseRow, mouseCol] = 'M';
                            continue;
                        }

                        cupboard[mouseRow, mouseCol] = '*';
                        mouseCol--;
                    }
                }
                if (command == "right")
                {
                    if (IsOutside(cupboard, mouseRow, mouseCol + 1))
                    {
                        isOutside = true;
                    }
                    else
                    {
                        if (isWall(cupboard, mouseRow, mouseCol + 1))
                        {
                            cupboard[mouseRow, mouseCol] = 'M';
                            continue;
                        }

                        cupboard[mouseRow, mouseCol] = '*';
                        mouseCol++;
                    }
                }
                if (command == "up")
                {
                    if (IsOutside(cupboard, mouseRow - 1, mouseCol))
                    {
                        isOutside = true;
                    }
                    else
                    {
                        if (isWall(cupboard, mouseRow - 1, mouseCol))
                        {
                            cupboard[mouseRow, mouseCol] = 'M';
                            continue;
                        }

                        cupboard[mouseRow, mouseCol] = '*';
                        mouseRow--;
                    }
                }
                if (command == "down")
                {
                    if (IsOutside(cupboard, mouseRow + 1, mouseCol))
                    {
                        isOutside = true;
                    }
                    else
                    {
                        if (isWall(cupboard, mouseRow + 1, mouseCol))
                        {
                            cupboard[mouseRow, mouseCol] = 'M';
                            continue;
                        }

                        cupboard[mouseRow, mouseCol] = '*';
                        mouseRow++;
                    }
                }

                char symbol = cupboard[mouseRow, mouseCol];
                cupboard[mouseRow, mouseCol] = 'M';

                if (isOutside)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }

                if (symbol == 'C')
                {
                    cheeseEaten++;
                }
                else if (symbol == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }

                if (cheeseCount == cheeseEaten)
                {
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }
            }

            if (command == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }

            if (cupboard[mouseRow, mouseCol] != 'M')
            {
                cupboard[mouseRow, mouseCol] = 'M';
            }

            for (int row = 0; row < cupboard.GetLength(0); row++)
            {
                for (int col = 0; col < cupboard.GetLength(1); col++)
                {
                    Console.Write(cupboard[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool isWall(char[,] cupboard, int row, int col) => cupboard[row, col] == '@';

        private static bool IsOutside(char[,] cupboard, int row, int col) => row < 0 || row >= cupboard.GetLength(0) || col < 0 || col >= cupboard.GetLength(1);
    }
}