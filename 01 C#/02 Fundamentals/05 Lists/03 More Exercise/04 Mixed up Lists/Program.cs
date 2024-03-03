List<int> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int temp;
int temp2;

if (list.Count > list2.Count)
{
    temp = list[list.Count - 1];
    temp2 = list[list.Count - 2];

}
else
{
    temp = list2[0];
    temp2 = list2[1];
}
int end = Math.Max(temp, temp2);
int start = Math.Min(temp, temp2);

List<int> combinedList = list;

combinedList.AddRange(list2);

combinedList = combinedList.Where((x) => x > start && x < end).ToList();

combinedList.Sort();

Console.WriteLine(string.Join(" ", combinedList));




//2
List<int> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int temp;
int temp2;

if (list.Count > list2.Count)
{
    temp = list[list.Count - 1];
    temp2 = list[list.Count - 2];
    list.RemoveRange(list.Count - 2, 2);
}
else
{
    temp = list2[0];
    temp2 = list2[1];
    list2.RemoveRange(0, 2);
}

int end = Math.Max(temp, temp2);
int start = Math.Min(temp, temp2);

List<int> combinedList = new List<int>(list.Count * 2);

for (int i = 0; i < list.Count; i++)
{
    combinedList.Add(list[i]);
    combinedList.Add(list2[list2.Count - 1 - i]);
}

FilterElements(combinedList, start, end);

combinedList.Sort();

Console.WriteLine(string.Join(" ", combinedList));

static void FilterElements(List<int> list, int start, int end)
{
    List<int> temp = new List<int>();

    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] > start && list[i] < end)
        {
            continue;
        }
        else
        {
            list.RemoveAt(i--);
        }
    }
}