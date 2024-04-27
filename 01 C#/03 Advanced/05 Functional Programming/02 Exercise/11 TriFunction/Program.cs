int number = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split();

Func<int, string, bool> func = (number, name) =>
{
    int sum = 0;

    foreach (var c in name)
    {
        sum += (int)c;
    }

    return sum >= number;
};

Func<string[], Func<int, string, bool>, string> func2 = (names, predicate) =>
{
    foreach (var name in names)
    {
        if (predicate(number, name))
        {
            return name;
        }
    }

    return "No name found";
};

Console.WriteLine(func2(names, func));