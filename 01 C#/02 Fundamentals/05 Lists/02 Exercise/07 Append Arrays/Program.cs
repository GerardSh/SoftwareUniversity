string lines = Console.ReadLine();
string newLines = "";

for (int i = 0; i < lines.Length; i++)
{
    if (lines[i] != '|')
    {
        newLines += lines[i];
    }
    else
    {
        newLines += " | ";
    }
}

List<string> list = newLines
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

List<string> newList = new List<string>(list.Count);

int count = 0;
while (list.Count > 0)
{
    bool listContains = list.Contains("|");

    if (!listContains || list[count] == "|")
    {
        if (!listContains)
        {
            count = list.Count;
        }

        for (int j = 0; j < count; j++)
        {
            newList.Add(list[count - 1 - j]);
            list.RemoveAt(count - 1 - j);
        }

        if (!listContains)
        {
            break;
        }

        list.RemoveAt(0);
        count = -1;
    }
    count++;
}

newList.Reverse();

Console.WriteLine(string.Join(" ", newList));




//2
List<string> arrays = Console.ReadLine()
    .Split("|", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

List<string> mergedArrays = new List<string>();

for (int i = arrays.Count - 1; i >= 0; i--)
{
    mergedArrays.AddRange(arrays[i]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToList());
}

Console.WriteLine(string.Join(" ", mergedArrays));