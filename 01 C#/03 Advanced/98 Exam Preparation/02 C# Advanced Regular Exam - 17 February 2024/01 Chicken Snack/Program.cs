using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var money = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var prices = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int foodCount = 0;

            while (money.Count > 0 && prices.Count > 0)
            {
                int currentMoney = money.Pop();
                int currentPrice = prices.Dequeue();

                int result = currentMoney - currentPrice;

                if (result == 0)
                {
                    foodCount++;
                }
                else if (result > 0)
                {
                    if (money.Count > 0)
                    {
                        int temp = money.Pop();
                        money.Push(temp + result);
                    }

                    foodCount++;
                }
            }

            if (foodCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
            }
            else if (foodCount > 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} foods.");
            }
            else if ( foodCount == 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} food");
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}