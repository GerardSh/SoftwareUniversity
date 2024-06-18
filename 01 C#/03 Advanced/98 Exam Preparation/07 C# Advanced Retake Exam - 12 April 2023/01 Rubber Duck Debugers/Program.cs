public class Program
{
    static void Main()
    {
        var programmerTime = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
        var tasks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

        var rewards = new Dictionary<string, int>()
        {
            {"Darth Vader Ducky", 0},
            {"Thor Ducky", 0},
            {"Big Blue Rubber Ducky", 0},
            {"Small Yellow Rubber Ducky", 0},

        };
        while (programmerTime.Any() && tasks.Any())
        {
            int time = programmerTime.Dequeue();
            int task = tasks.Pop();

            int result = time * task;

            if (result <= 60)
            {
                rewards["Darth Vader Ducky"]++;
            }
            else if (result <= 120)
            {
                rewards["Thor Ducky"]++;
            }
            else if (result <= 180)
            {
                rewards["Big Blue Rubber Ducky"]++;
            }
            else if (result <= 240)
            {
                rewards["Small Yellow Rubber Ducky"]++;
            }
            else if (result > 240)
            {
                task -= 2;
                tasks.Push(task);
                programmerTime.Enqueue(time);
            }
        }

        Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

        foreach (var kvp in rewards)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
