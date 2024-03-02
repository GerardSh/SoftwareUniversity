List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

string[] commands = Console.ReadLine().Split();

while (commands[0] != "end")
{
    string command = commands[0];

    if (command == "Add")
    {
        int number = int.Parse(commands[1]);

        AddNumber(list, number);
    }
    else if (command == "Remove")
    {
        int number = int.Parse(commands[1]);

        RemoveNumber(list, number);
    }
    else if (command == "RemoveAt")
    {
        int number = int.Parse(commands[1]);

        RemoveIndex(list, number);
    }
    else if (command == "Insert")
    {
        int number = int.Parse(commands[1]);
        int index = int.Parse(commands[2]);

        Insert(list, number, index);
    }

    commands = Console.ReadLine().Split();
}

Console.WriteLine(string.Join(" ", list));

static void Insert(List<int> list, int number, int index)
{
    list.Insert(index, number);
}

static void RemoveIndex(List<int> list, int index)
{
    list.RemoveAt(index);
}

static void RemoveNumber(List<int> list, int number)
{
    list.RemoveAll(Remove);
    //list.RemoveAll(n => n == number);

    bool Remove(int n)
    {
        return n == number;
    }
}

static void AddNumber(List<int> list, int number)
{
    list.Add(number);
}