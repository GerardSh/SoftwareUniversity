List<int> train = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int maxCapacity = int.Parse(Console.ReadLine());

string[] input;

while ((input = Console.ReadLine()
    .Split())[0] != "end")
{
    string command = input[0];

    if (command == "Add")
    {
        int passangers = int.Parse(input[1]);

        train.Add(passangers);
    }
    else
    {
        int newPassangers = int.Parse(input[0]);

        for (int i = 0; i < train.Count; i++)
        {
            int freeSpace = maxCapacity - train[i];

            if (newPassangers <= freeSpace)
            {
                train[i] += newPassangers;
                break;
            }
        }
    }
}

Console.WriteLine(string.Join(" ", train));