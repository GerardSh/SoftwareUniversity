namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            var lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wreathCount = 0;
            int storedSum = 0;

            while (roses.Any() && lilies.Any())
            {
                int rose = roses.Dequeue();
                int lily = lilies.Pop();

                int sum = rose + lily;

                while (sum >= 15)
                {
                    if (sum == 15)
                    {
                        wreathCount++;
                        break;
                    }

                    sum -= 2;
                }

                if (sum < 15)
                {
                    storedSum += sum;
                }
            }

            wreathCount += storedSum / 15;

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}