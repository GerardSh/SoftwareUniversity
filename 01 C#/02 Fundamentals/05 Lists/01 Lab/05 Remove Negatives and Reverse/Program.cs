List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

RemoveNegatives(numbers);
numbers.Reverse();

if (numbers.Count > 0)
{
    Console.WriteLine(string.Join(" ", numbers));
}
else
{
    Console.WriteLine("empty");
}


static void RemoveNegatives(List<int> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] < 0)
        {
            list.RemoveAt(i);
            i = -1;
        }
    }
}