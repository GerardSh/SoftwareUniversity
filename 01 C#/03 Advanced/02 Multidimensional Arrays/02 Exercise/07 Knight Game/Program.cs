class Knight
{
    public int[] Position { get; set; }
    public int Count { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        bool[,] chess = new bool[n, n];
        int removedKnightsSum = 0;
        int knightsCount = 0;

        CreatingTable(chess);

        List<Knight> knights = new List<Knight>();

        knights = GetKnights(chess);

        while (knights.Count > 0)
        {
            chess[knights[0].Position[0], knights[0].Position[1]] = false;
            knights.RemoveAt(0);
            removedKnightsSum++;
            knights = GetKnights(chess);
        }

        Console.WriteLine(removedKnightsSum);
    }

    private static List<Knight> GetKnights(bool[,] chess)
    {
        List<Knight> knights = new List<Knight>();

        for (int row = 0; row < chess.GetLength(0); row++)
        {
            for (int col = 0; col < chess.GetLength(1); col++)
            {
                if (chess[row, col] == true)
                {
                    int knightsInRange = CountKnightsInRange(chess, row, col);
                    int[] knightPosition = { row, col };

                    if (knightsInRange == 0)
                    {
                        continue;
                    }

                    knights.Add(new Knight()
                    {
                        Count = knightsInRange,
                        Position = knightPosition
                    });
                }
            }
        }

        return knights.OrderByDescending(x => x.Count).ToList();
    }

    static int CountKnightsInRange(bool[,] chess, int row, int col)
    {
        int count = 0;

        if (row + 2 < chess.GetLength(0))
        {
            if (col + 2 < chess.GetLength(1) && chess[row + 1, col + 2] == true)
            {
                count++;
            }
            if (col > 1 && chess[row + 1, col - 2] == true)
            {
                count++;
            }
            if (col + 1 < chess.GetLength(1) && chess[row + 2, col + 1] == true)
            {
                count++;
            }
            if (col > 0 && chess[row + 2, col - 1] == true)
            {
                count++;
            }
        }
        else if (row + 1 == chess.GetLength(0) - 1)
        {
            if (col + 2 < chess.GetLength(1) && chess[row + 1, col + 2] == true)
            {
                count++;
            }
            if (col > 1 && chess[row + 1, col - 2] == true)
            {
                count++;
            }
        }

        if (row < chess.GetLength(0))
        {
            if (row - 1 >= 0)
            {
                if (col + 2 < chess.GetLength(1) && chess[row - 1, col + 2] == true)
                {
                    count++;
                }
                if (col > 1 && chess[row - 1, col - 2] == true)
                {
                    count++;
                }
                if (row - 1 > 0 && col + 1 < chess.GetLength(1) && chess[row - 2, col + 1] == true)
                {
                    count++;
                }
                if (row - 1 > 0 && col > 0 && chess[row - 2, col - 1] == true)
                {
                    count++;
                }
            }
        }

        return count;
    }

    static void CreatingTable(bool[,] chess)
    {
        for (int i = 0; i < chess.GetLength(0); i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < chess.GetLength(1); j++)

                if (line[j] == 'K')
                {
                    chess[i, j] = true;
                }
                else
                {
                    chess[i, j] = false;
                }
        }
    }
}




//2
int n = int.Parse(Console.ReadLine());

bool[,] chess = new bool[n, n];
int removedKnightsSum = 0;

CreatingTable(chess);

while (true)
{
    int knightMaxRange = 0;
    int knightMaxRangeRow = 0;
    int knightMaxRangeCol = 0;

    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            int currentKnightRange = 0;

            if (chess[row, col] == true)
            {
                if (ValidMove(chess, row - 2, col - 1) && chess[row - 2, col - 1] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row - 2, col + 1) && chess[row - 2, col + 1] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row - 1, col - 2) && chess[row - 1, col - 2] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row - 1, col + 2) && chess[row - 1, col + 2] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row + 2, col + 1) && chess[row + 2, col + 1] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row + 2, col - 1) && chess[row + 2, col - 1] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row + 1, col + 2) && chess[row + 1, col + 2] == true)
                {
                    currentKnightRange++;
                }
                if (ValidMove(chess, row + 1, col - 2) && chess[row + 1, col - 2] == true)
                {
                    currentKnightRange++;
                }

                if (currentKnightRange > knightMaxRange)
                {
                    knightMaxRange = currentKnightRange;
                    knightMaxRangeCol = col;
                    knightMaxRangeRow = row;
                }
            }
        }
    }

    if (knightMaxRange > 0)
    {
        chess[knightMaxRangeRow, knightMaxRangeCol] = false;
        removedKnightsSum++;
        continue;
    }

    break;
}

Console.WriteLine(removedKnightsSum);

bool ValidMove(bool[,] chess, int row, int col)
{
    return row >= 0 && row < chess.GetLength(0) && col >= 0 && col < chess.GetLength(1);
}

static void CreatingTable(bool[,] chess)
{
    for (int i = 0; i < chess.GetLength(0); i++)
    {
        string line = Console.ReadLine();

        for (int j = 0; j < chess.GetLength(1); j++)

            if (line[j] == 'K')
            {
                chess[i, j] = true;
            }
            else
            {
                chess[i, j] = false;
            }
    }
}