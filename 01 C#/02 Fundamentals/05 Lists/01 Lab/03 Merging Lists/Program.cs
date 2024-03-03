List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> resultList = new List<int>(list.Count + list2.Count);

int limit = GetGreaterCount(list, list2);

for (int i = 0; i <= limit; i++)
{
    if (i < list.Count)
    {
        resultList.Add(list[i]);
    }

    if (i < list2.Count)
    {
        resultList.Add(list2[i]);
    }
}

Console.WriteLine(string.Join(" ", resultList));


static int GetGreaterCount(List<int> list, List<int> list2)
{
    if (list.Count > list2.Count)
    {
        return list.Count;
    }
    else
    {
        return list2.Count;
    }
}




//2
List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> resultList = new List<int>(list.Count + list2.Count);

int smallerList = GetSmallerList(list, list2);

for (int i = 0; i < smallerList; i++)
{
    resultList.Add(list[i]);
    resultList.Add(list2[i]);
}

resultList = GetRemainingElements(list, list2, resultList);


Console.WriteLine(string.Join(" ", resultList));


static int GetSmallerList(List<int> list, List<int> list2)
{
    if (list.Count < list2.Count)
    {
        return list.Count;
    }
    else
    {
        return list2.Count;
    }
}

static List<int> GetRemainingElements(List<int> list, List<int> list2, List<int> resultList)
{
    if (list.Count > list2.Count)
    {
        for (int i = list2.Count; i < list.Count; i++)
        {
            resultList.Add(list[i]);
        }
    }
    else
    {
        for (int i = list.Count; i < list2.Count; i++)
        {
            resultList.Add(list2[i]);
        }
    }

    return resultList;
}




//3
List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> resultList = new List<int>(list.Count + list2.Count);

for (int i = 0; i < Math.Min(list.Count, list2.Count); i++)
{
    resultList.Add(list[i]);
    resultList.Add(list2[i]);
}

if (list.Count > list2.Count)
{

    resultList.AddRange(GetRemainingElements(list, list2));
}
else
{
    resultList.AddRange(GetRemainingElements(list2, list));
}


Console.WriteLine(string.Join(" ", resultList));


static List<int> GetRemainingElements(List<int> biggerList, List<int> shorterList)
{
    List<int> remainingElements = new List<int>();

    for (int i = shorterList.Count; i < biggerList.Count; i++)
    {
        remainingElements.Add(biggerList[i]);
    }

    return remainingElements;
}




//4
List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> resultList = new List<int>(list.Count + list2.Count);

for (int i = 0; i < Math.Min(list.Count, list2.Count); i++)
{
    resultList.Add(list[i]);
    resultList.Add(list2[i]);
}

if (list.Count > list2.Count)
{
    resultList.AddRange(list.Skip(list2.Count));
}
else
{
    resultList.AddRange(list2.Skip(list.Count));
}

Console.WriteLine(string.Join(" ", resultList));