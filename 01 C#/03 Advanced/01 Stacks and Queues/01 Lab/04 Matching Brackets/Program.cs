string input = Console.ReadLine();

Stack<int> stack = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{

    if (input[i] == '(')
    {
        stack.Push(i);
    }

    if (input[i] == ')')
    {
        int startIndx = stack.Pop();
        int count = i - startIndx + 1;

        Console.WriteLine(input.Substring(startIndx, count));
    }
}