namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] battlefield = new char[n, n];

            int shipRow = 0;
            int shipCol = 0;

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    battlefield[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }
                }
            }

            int minesHit = 0;
            int sinkedCruisers = 0;

            string command;

            while (minesHit < 3 && sinkedCruisers < 3 && (command = Console.ReadLine()) != "Finish")
            {
                battlefield[shipRow, shipCol] = '-';

                if (command == "up")
                {
                    shipRow--;
                }
                else if (command == "down")
                {
                    shipRow++;
                }
                else if (command == "left")
                {
                    shipCol--;
                }
                else if (command == "right")
                {
                    shipCol++;
                }

                if (battlefield[shipRow, shipCol] == '*')
                {
                    minesHit++;
                }
                else if (battlefield[shipRow, shipCol] == 'C')
                {
                    sinkedCruisers++;
                }

                battlefield[shipRow, shipCol] = 'S';

                if (minesHit == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{shipRow}, {shipCol}]!");
                }

                if (sinkedCruisers == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                }
            }

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    Console.Write(battlefield[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}