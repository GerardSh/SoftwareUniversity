namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var firstLootBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var secondLootBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int sumOfItems = 0;

            while (firstLootBox.Any() && secondLootBox.Any())
            {
                int firstItem = firstLootBox.Peek();
                int secondItem = secondLootBox.Pop();

                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    sumOfItems += sum;
                    firstLootBox.Dequeue();
                }
                else
                {
                    firstLootBox.Enqueue(secondItem);
                }
            }

            if (!firstLootBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumOfItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfItems}");
            }
        }
    }
}