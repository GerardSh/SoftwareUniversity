namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetSum = int.Parse(Console.ReadLine());

            var countByCoins = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {countByCoins.Values.Sum()}");

            foreach (var coin in countByCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderByDescending(x => x).ToList();

            var countByCoins = new Dictionary<int, int>();

            //Option 1
            for (int i = 0; i < coins.Count && targetSum > 0; i++)
            {
                int currentCoin = coins[i];

                int possibleCoinsCount = targetSum / currentCoin;

                if (possibleCoinsCount == 0)
                {
                    continue;
                }

                targetSum %= currentCoin;
                //targetSum -= possibleCoins * currentCoin;

                countByCoins[coins[i]] = possibleCoinsCount;
            }

            //Option 2
            //int currentIndex = 0;

            //while (targetSum > 0 && currentIndex < coins.Count)
            //{
            //    int currentCoin = coins[currentIndex];

            //    int possibleCoinsCount = targetSum / currentCoin;

            //    if (possibleCoinsCount == 0)
            //    {
            //        currentIndex++;
            //        continue;
            //    }

            //    targetSum %= currentCoin;

            //    countByCoins[currentCoin] = possibleCoinsCount;

            //    currentIndex++;
            //}

            if (targetSum != 0)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            return countByCoins;
        }
    }
}