namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] pond = new char[n, n];

            int beaverRow = 0;
            int beaverCol = 0;

            int countBranches = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (char.IsLower(currentRow[col]))
                    {
                        countBranches++;
                    }
                }
            }

            string command;
            var branches = new Stack<char>();
            int collectedBranches = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up" && beaverRow == 0
                    || command == "down" && beaverRow == pond.GetLength(0) - 1
                    || command == "left" && beaverCol == 0
                    || command == "right" && beaverCol == pond.GetLength(1) - 1)
                {
                    if (branches.Any())
                    {
                        branches.Pop();
                    }

                    continue;
                }

                pond[beaverRow, beaverCol] = '-';

                if (command == "up")
                {
                    beaverRow--;
                }
                else if (command == "down")
                {
                    beaverRow++;
                }
                else if (command == "left")
                {
                    beaverCol--;
                }
                else if (command == "right")
                {
                    beaverCol++;
                }

                while (pond[beaverRow, beaverCol] == 'F')
                {
                    pond[beaverRow, beaverCol] = '-';

                    if (command == "up")
                    {
                        if (beaverRow == 0)
                        {
                            beaverRow = pond.GetLength(0) - 1;
                        }
                        else
                        {
                            beaverRow = 0;
                        }
                    }
                    else if (command == "down")
                    {
                        if (beaverRow == pond.GetLength(0) - 1)
                        {
                            beaverRow = 0;
                        }
                        else
                        {
                            beaverRow = pond.GetLength(0) - 1;
                        }
                    }
                    else if (command == "left")
                    {
                        if (beaverCol == 0)
                        {
                            beaverCol = pond.GetLength(1) - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                    }
                    else if (command == "right")
                    {
                        if (beaverCol == pond.GetLength(1) - 1)
                        {
                            beaverCol = 0;
                        }
                        else
                        {
                            beaverCol = pond.GetLength(1) - 1;
                        }
                    }
                }

                if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    branches.Push(pond[beaverRow, beaverCol]);
                    collectedBranches++;
                }

                pond[beaverRow, beaverCol] = 'B';

                if (collectedBranches == countBranches)
                {
                    break;
                }
            }

            if (collectedBranches == countBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countBranches - collectedBranches} branches left.");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                List<char> list = new List<char>();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    list.Add(pond[row, col]);
                }

                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}