int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Stack<int> stack = new Stack<int>();

foreach (int number in numbers)
{
    stack.Push(number);
}

string input;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "add")
    {
        stack.Push(int.Parse(commands[1]));
        stack.Push(int.Parse(commands[2]));
    }
    else
    {
        int number = int.Parse(commands[1]);

        if (stack.Count >= number)
        {
            while (number > 0)
            {
                number--;
                stack.Pop();
            }
        }
    }
}

Console.WriteLine("Sum: " + stack.Sum());
