string input = Console.ReadLine();

Stack<char> stack = new Stack<char>(input);
Queue<char> queue = new Queue<char>(input);

bool isEqual = true;

if (input.Length % 2 != 0)
{
    Console.WriteLine("NO");
    return;
}

for (int i = 0; i < input.Length / 2; i++)
{
    char firstChar = queue.Dequeue();
    char secondChar = stack.Pop();

    if (firstChar == '{' && secondChar != '}'
        || firstChar == '[' && secondChar != ']'
        || firstChar == '(' && secondChar != ')')
    {
        isEqual = false;
        break;
    }
}


if (isEqual)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}