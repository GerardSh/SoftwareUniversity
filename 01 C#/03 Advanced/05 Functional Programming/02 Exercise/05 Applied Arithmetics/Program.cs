int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string input;

Action<int[]> printCollection = numbers => Console.WriteLine(string.Join(" ", numbers));

while ((input = Console.ReadLine()) != "end")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    Func<int, int> arithmeticFunc = null;

    if (command == "add")
    {
        arithmeticFunc = numb => numb + 1;
    }
    else if (command == "multiply")
    {
        arithmeticFunc = numb => numb * 2;
    }
    else if (command == "subtract")
    {
        arithmeticFunc = (numb) => numb - 1;
    }
    else if (command == "print")
    {
        printCollection(numbers);
        continue;
    }

    numbers = numbers.Select(arithmeticFunc).ToArray();
}