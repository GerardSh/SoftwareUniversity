int n = int.Parse(Console.ReadLine());

Stack<int> stack = new Stack<int>(n);

for (int i = 0; i < n; i++)
{
    int[] elements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int command = elements[0];

    if (command == 1)
    {
        int numberToAdd = elements[1];

        stack.Push(numberToAdd);
    }
    else if (command == 2)
    {
        if (stack.Count > 0)
        {
            stack.Pop();
        }
    }
    else
    {
        if (stack.Count > 0)
        {
            Console.WriteLine(command == 3 ? stack.Max() : stack.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", stack));