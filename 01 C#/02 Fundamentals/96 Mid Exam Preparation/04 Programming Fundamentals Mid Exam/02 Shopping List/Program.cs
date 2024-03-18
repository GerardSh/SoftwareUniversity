List<string> shoppingList = Console.ReadLine()
    .Split("!", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "Go Shopping!")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    string item = commands[1];

    if (command == "Urgent")
    {
        if (!shoppingList.Contains(item))
        {
            shoppingList.Insert(0, item);
        }
    }
    else if (command == "Unnecessary")
    {
        shoppingList.Remove(item);
    }
    else if (command == "Correct")
    {
        string newItem = commands[2];

        int indexOldItem;

        if ((indexOldItem = shoppingList.IndexOf(item)) != -1)
        {
            shoppingList[indexOldItem] = newItem;
        }
    }
    else
    {
        if (shoppingList.Contains(item))
        {
            shoppingList.Remove(item);
            shoppingList.Add(item);
        }
    }
}

Console.WriteLine(string.Join(", ", shoppingList));