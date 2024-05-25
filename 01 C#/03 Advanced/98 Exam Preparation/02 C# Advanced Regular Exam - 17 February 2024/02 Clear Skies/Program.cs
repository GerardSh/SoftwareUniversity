using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int jetfighterArmor = 300;
            int enemyJetsCount = 0;
            int jetfighterRow = 0;
            int jetfighterCol = 0;
            char[,] airspace = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    airspace[row, col] = currentRow[col];

                    if (currentRow[col] == 'J')
                    {
                        jetfighterRow = row;
                        jetfighterCol = col;
                    }

                    if (currentRow[col] == 'E')
                    {
                        enemyJetsCount++;
                    }
                }
            }

            bool gameOver = false;

            while (!gameOver)
            {
                string direction = Console.ReadLine();

                airspace[jetfighterRow, jetfighterCol] = '-';

                if (direction == "up")
                {
                    jetfighterRow--;
                }
                else if (direction == "down")
                {
                    jetfighterRow++;
                }
                else if (direction == "left")
                {
                    jetfighterCol--;
                }
                else if (direction == "right")
                {
                    jetfighterCol++;
                }

                if (airspace[jetfighterRow, jetfighterCol] == 'E')
                {
                    jetfighterArmor -= 100;

                    if (jetfighterArmor == 0)
                    {
                        gameOver = true;
                    }
                    else
                    {
                        enemyJetsCount--;
                    }

                    if (enemyJetsCount == 0)
                    {
                        gameOver = true;
                    }
                }
                else if (airspace[jetfighterRow, jetfighterCol] == 'R')
                {
                    jetfighterArmor = 300;
                }

                airspace[jetfighterRow, jetfighterCol] = 'J';
            }

            if (jetfighterArmor > 0)
            {
                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            }
            else
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetfighterRow}, {jetfighterCol}]!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(airspace[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}