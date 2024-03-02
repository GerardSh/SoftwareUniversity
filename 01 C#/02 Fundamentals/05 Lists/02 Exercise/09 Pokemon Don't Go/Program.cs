List<int> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int sumRemovedElements = 0;


while (list.Count > 0)
{
    int index = int.Parse(Console.ReadLine());
    int removedElement;

    if (index < 0)
    {
        removedElement = list[0];
        list[0] = list[list.Count - 1];
    }
    else if (index > list.Count - 1)
    {
        removedElement = list[list.Count - 1];
        list[list.Count - 1] = list[0];
    }
    else
    {
        removedElement = list[index];
        list.RemoveAt(index);
    }

    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] <= removedElement)
        {
            list[i] += removedElement;
        }
        else
        {
            list[i] -= removedElement;
        }
    }

    sumRemovedElements += removedElement;
}

Console.WriteLine(sumRemovedElements);