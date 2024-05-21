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
            
            int currentSum = 0;

            coins = coins.OrderByDescending(x => x).ToList();

            var countByCoins = new Dictionary<int, int>();

            //Option 1
            for (int i = 0; i < coins.Count && currentSum < targetSum; i++)
            {
                int possibleCoins = (targetSum - currentSum) / coins[i];

                if (possibleCoins == 0)
                {
                    continue;
                }

                currentSum += possibleCoins * coins[i];

                countByCoins[coins[i]] = possibleCoins;
            }

            //Option 2
            //int currentIndex = 0;

            //while (currentSum < targetSum && currentIndex < coins.Count)
            //{
            //    int possibleCoins = (targetSum - currentSum) / coins[currentIndex];

            //    if (possibleCoins == 0)
            //    {
            //        currentIndex++;
            //        continue;
            //    }

            //    currentSum += possibleCoins * coins[currentIndex];

            //    countByCoins[coins[currentIndex]] = possibleCoins;

            //    currentIndex++;
            //}

            if (currentSum != targetSum)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            return countByCoins;
        }
    }
}