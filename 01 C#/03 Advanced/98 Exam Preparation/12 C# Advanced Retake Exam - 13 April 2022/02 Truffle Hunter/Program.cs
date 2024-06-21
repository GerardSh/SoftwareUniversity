namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var collectedTruffles = new Dictionary<string, int>()
            {
                {"Black truffle", 0},
                {"Summer truffle", 0},
                {"White truffle", 0},
            };

            string[,] forrest = new string[n, n];

            for (int row = 0; row < forrest.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ");

                for (int col = 0; col < forrest.GetLength(1); col++)
                {
                    forrest[row, col] = currentRow[col];
                }
            }

            int wildBoarTruffels = 0;
            string input;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] elements = input.Split();


                string command = elements[0];
                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);

                if (command == "Collect")
                {
                    if (row < 0 || row >= forrest.GetLength(0) || col < 0 || col >= forrest.GetLength(1))
                    {
                        continue;
                    }

                    if (forrest[row, col] != "-")
                    {
                        CollectTruffles(collectedTruffles, forrest[row, col]);
                        forrest[row, col] = "-";
                    }
                }
                else
                {
                    string direction = elements[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (forrest[i, col] != "-")
                            {
                                wildBoarTruffels++;
                            }

                            forrest[i, col] = "-";
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < forrest.GetLength(0); i += 2)
                        {
                            if (forrest[i, col] != "-")
                            {
                                wildBoarTruffels++;
                            }

                            forrest[i, col] = "-";
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (forrest[row, i] != "-")
                            {
                                wildBoarTruffels++;
                            }

                            forrest[row, i] = "-";
                        }
                    }
                    else
                    {
                        for (int i = col; i < forrest.GetLength(1); i += 2)
                        {
                            if (forrest[row, i] != "-")
                            {
                                wildBoarTruffels++;
                            }

                            forrest[row, i] = "-";
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {collectedTruffles["Black truffle"]} black, {collectedTruffles["Summer truffle"]} summer, and {collectedTruffles["White truffle"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffels} truffles.");

            for (int row = 0; row < forrest.GetLength(0); row++)
            {
                List<string> list = new List<string>();

                for (int col = 0; col < forrest.GetLength(1); col++)
                {
                    list.Add(forrest[row, col]);
                }

                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static void CollectTruffles(Dictionary<string, int> collectedTruffles, string truffelSymbol)
        {
            string truffle = null;

            if (truffelSymbol == "B")
            {
                truffle = "Black truffle";
            }
            else if (truffelSymbol == "S")
            {
                truffle = "Summer truffle";
            }
            else
            {
                truffle = "White truffle";
            }

            collectedTruffles[truffle]++;
        }
    }
}