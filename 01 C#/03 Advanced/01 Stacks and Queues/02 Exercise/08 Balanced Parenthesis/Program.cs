string input = Console.ReadLine();

if (input.Length % 2 != 0 || input.Length == 0)
{
    Console.WriteLine("NO");
    return;
}

Stack<char> stack = new Stack<char>();

bool isBalanced = true;

for (int i = 0; i < input.Length && isBalanced; i++)
{
    if (input[i] == '(' || input[i] == '[' || input[i] == '{')
    {
        stack.Push(input[i]);
    }
    else
    {
        if (stack.Count == 0
            || input[i] == ')' && stack.Pop() != '('
            || input[i] == ']' && stack.Pop() != '['
            || input[i] == '}' && stack.Pop() != '{')
        {
            isBalanced = false;
            break;
        }
    }
}

if (isBalanced)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}