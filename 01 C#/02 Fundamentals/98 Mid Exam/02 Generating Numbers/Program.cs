List<int> numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "add")
    {
        List<int> tempList = new List<int>();

        for (int i = 3; i < elements.Length; i++)
        {
            tempList.Add(int.Parse(elements[i]));
        }

        numbers.InsertRange(0, tempList);
    }
    else if (command == "remove" && elements[1] == "greater")
    {
        int value = int.Parse(elements[3]);

        numbers = numbers.Where(x => x <= value).ToList();
    }
    else if (command == "replace")
    {
        int value = int.Parse(elements[1]);
        int replacement = int.Parse(elements[2]);

        int index = numbers.IndexOf(value);

        if (index >= 0)
        {
            numbers[index] = replacement;
        }
    }
    else if (command == "remove" && elements[1] == "at")
    {
        int index = int.Parse(elements[3]);

        if (index < 0 || index >= numbers.Count)
        {
            continue;
        }

        numbers.RemoveAt(index);
    }
    else if (command == "find" && elements[1] == "even")
    {
        List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();

        Console.WriteLine(string.Join(" ", evenNumbers));
    }
    else if (command == "find" && elements[1] == "odd")
    {
        List<int> oddNumbers = numbers.Where(x => x % 2 == 1).ToList();
        Console.WriteLine(string.Join(" ", oddNumbers));
    }
}

Console.WriteLine(string.Join(", ", numbers));
//09:30:21 04.04.2024