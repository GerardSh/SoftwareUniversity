List<string> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "3:1")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "merge")
    {
        MergeElements(commands, list);
    }
    else
    {
        int index = int.Parse(commands[1]);
        int partitions = int.Parse(commands[2]);
        string currentElement = list[index];

        int partitionLength = currentElement.Length / partitions;
        int count = 0;
        string partitionedValue = "";
        List<string> tempList = new List<string>(partitions);

        for (int i = 0; i < currentElement.Length; i++)
        {
            count++;
            partitionedValue += currentElement[i];

            if (count == partitionLength && tempList.Count < partitions - 1 || i == currentElement.Length - 1)
            {
                tempList.Add(partitionedValue);
                partitionedValue = "";
                count = 0;
            }
        }

        list.RemoveAt(index);
        tempList.Reverse();

        for (int i = 0; i < tempList.Count; i++)
        {
            list.Insert(index, tempList[i]);
        }
    }
}

Console.WriteLine(string.Join(" ", list));

;
static void MergeElements(string[] commands, List<string> list)
{
    int startIndex = int.Parse(commands[1]);
    int endIndex = int.Parse(commands[2]);

    if (startIndex < 0)
    {
        startIndex = 0;
    }
    if (endIndex > list.Count - 1)
    {
        endIndex = list.Count - 1;
    }

    string mergedValues = "";
    bool mergedSuccess = false;

    for (int i = startIndex; i <= endIndex; i++)
    {
        mergedValues += list[startIndex];
        list.RemoveAt(startIndex);
        mergedSuccess = true;
    }

    if (mergedSuccess)
    {
        list.Insert(startIndex, mergedValues);
    }
}




//2
List<string> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "3:1")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "merge")
    {
        int startIndex = int.Parse(commands[1]);
        int endIndex = int.Parse(commands[2]);

        if (startIndex < 0)
        {
            startIndex = 0;
        }

        if (endIndex > list.Count - 1)
        {
            endIndex = list.Count - 1;
        }

        if (endIndex < startIndex)
        {
            continue;
        }

        string mergedElemenets = "";

        for (int i = startIndex; i <= endIndex; i++)
        {
            mergedElemenets += list[i];
        }

        list.RemoveRange(startIndex, endIndex - startIndex + 1);
        list.Insert(startIndex, mergedElemenets);
    }
    else if (command == "divide")
    {
        int index = int.Parse(commands[1]);
        int partitions = int.Parse(commands[2]);

        string element = list[index];
        list.RemoveAt(index);

        int partitionSize = element.Length / partitions;

        string[] subElements = new string[partitions];

        for (int i = 0; i < partitions - 1; i++)
        {
            subElements[i] = element.Substring(partitionSize * i, partitionSize);
        }

        subElements[subElements.Length - 1] = element.Substring((partitions - 1) * partitionSize);

        list.InsertRange(index, subElements);
    }
}

Console.WriteLine(string.Join(" ", list));