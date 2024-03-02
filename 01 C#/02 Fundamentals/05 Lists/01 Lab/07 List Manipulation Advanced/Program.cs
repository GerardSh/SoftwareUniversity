List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

string[] commands;
bool hasChanged = false;

while ((commands = Console.ReadLine().Split().ToArray())[0] != "end")
{
    string command = commands[0];

    if (command == "Add")
    {
        int number = int.Parse(commands[1]);
        hasChanged = true;

        AddNumber(list, number);
    }
    else if (command == "Remove")
    {
        int number = int.Parse(commands[1]);
        hasChanged = true;

        RemoveNumber(list, number);
    }
    else if (command == "RemoveAt")
    {
        int number = int.Parse(commands[1]);
        hasChanged = true;

        RemoveIndex(list, number);
    }
    else if (command == "Insert")
    {
        int number = int.Parse(commands[1]);
        int index = int.Parse(commands[2]);
        hasChanged = true;

        Insert(list, number, index);
    }

    else if (command == "Contains")
    {
        int number = int.Parse(commands[1]);

        if (list.Contains(number))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No such number");
        }
    }
    else if (command == "PrintEven" || command == "PrintOdd")
    {
        PrintNumbers(list, command);
    }
    else if (command == "GetSum")
    {
        Console.WriteLine(list.Sum());
    }
    else if (command == "Filter")
    {
        string sign = commands[1];
        int number = int.Parse(commands[2]);

        FilterElements(list, sign, number);
    }
}

if (hasChanged)
{
    Console.WriteLine(string.Join(" ", list));
}

void FilterElements(List<int> list, string sign, int number)
{
    List<int> filteredElements = new List<int>(list.Count);

    if (sign == ">=")
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] >= number)
                filteredElements.Add(list[i]);
        }
    }
    else if (sign == "<")
    {
        filteredElements = list.Where(n => n < number).ToList();
    }
    else if (sign == ">")
    {
        filteredElements = list.Where(n => n > number).ToList();
    }
    else if (sign == "<=")
    {
        filteredElements = list.Where(n => n <= number).ToList();
    }

    Console.WriteLine(string.Join(" ", filteredElements));
}

static void PrintNumbers(List<int> list, string parameter)
{
    int parity = CheckParity(parameter);

    List<int> temp = list.Where(n => n % 2 == parity).ToList();

    Console.WriteLine(string.Join(" ", temp));

    //for (int i = 0; i < list.Count; i++)
    //{
    //    if (list[i] % 2 == parity)
    //    {
    //        Console.Write(list[i] + " ");
    //    }
    //}
}

static int CheckParity(string parity)
{
    if (parity.Contains("Even"))
    {
        return 0;
    }
    else
    {
        return 1;
    }
}

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