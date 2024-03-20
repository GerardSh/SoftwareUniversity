string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Stack<string> stack = new Stack<string>();

foreach (string number in numbers)
{
    stack.Push(number);
}

int sum = 0;

while (stack.Count > 0)
{
    int lastNumber = int.Parse(stack.Pop());

    if (stack.Count > 0 && stack.Pop() == "-")
    {
        lastNumber *= -1;
    }

    sum += lastNumber;
}

Console.WriteLine(sum);