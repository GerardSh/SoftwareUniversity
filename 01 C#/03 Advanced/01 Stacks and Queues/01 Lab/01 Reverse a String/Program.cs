string input = Console.ReadLine();

Stack<char> stack = new Stack<char>();

foreach (char c in input)
{
    stack.Push(c);
}

while (stack.Count > 0)
{
    Console.WriteLine(stack.Pop());
}