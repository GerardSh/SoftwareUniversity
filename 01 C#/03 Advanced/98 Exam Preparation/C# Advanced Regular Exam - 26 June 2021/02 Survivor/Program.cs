using System.ComponentModel.DataAnnotations;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[][] beach = new string[n][];

            for (int row = 0; row < beach.Length; row++)
            {
                string[] currentRow = Console.ReadLine().Split();
                beach[row] = currentRow;
            }

            int countOfCollected = 0;
            int countOfOpponentsTokens = 0;

            string input;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] elements = input.Split();

                string command = elements[0];
                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);

                if (command == "Find")
                {
                    if (!ValidCoordinates(beach, row, col))
                    {
                        continue;
                    }

                    countOfCollected += IncreaseTokens(beach, row, col);
                }
                else
                {
                    string direction = elements[3];

                    if (!ValidCoordinates(beach, row, col))
                    {
                        continue;
                    }

                    countOfOpponentsTokens += IncreaseTokens(beach, row, col);

                    for (int i = 0; i < 3; i++)
                    {
                        if (direction == "up")
                        {
                            if (!ValidCoordinates(beach, --row, col))
                            {
                                continue;
                            }

                            countOfOpponentsTokens += IncreaseTokens(beach, row, col);
                        }
                        else if (direction == "down")
                        {
                            if (!ValidCoordinates(beach, ++row, col))
                            {
                                continue;
                            }

                            countOfOpponentsTokens += IncreaseTokens(beach, row, col);
                        }
                        else if (direction == "left")
                        {
                            if (!ValidCoordinates(beach, row, --col))
                            {
                                continue;
                            }

                            countOfOpponentsTokens += IncreaseTokens(beach, row, col);
                        }
                        else if (direction == "right")
                        {
                            if (!ValidCoordinates(beach, row, ++col))
                            {
                                continue;
                            }

                            countOfOpponentsTokens += IncreaseTokens(beach, row, col);
                        }
                    }
                }
            }

            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }

            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }

        private static int IncreaseTokens(string[][] beach, int row, int col)
        {
            if (beach[row][col] == "T")
            {
                beach[row][col] = "-";
                return 1;
            }

            return 0;
        }

        private static bool ValidCoordinates(string[][] beach, int row, int col) => row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length;
    }
}