List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

int count = Iterations(list.Count);

List<int> newList = new List<int>(count);

for (int i = 0; i < count; i++)
{
    if (i == list.Count - 1 - i)
    {
        newList.Add(list[i]);
    }
    else
    {
        newList.Add(list[i] + list[list.Count - 1 - i]);
    }

}

Console.WriteLine(string.Join(" ", newList));

static int Iterations(int count)
{
    if (count % 2 == 1)
    {
        return count / 2 + 1;
    }
    else
    {
        return count / 2;
    }
}

////2 
//List<int> numbers = Console.ReadLine()
//    .Split()
//    .Select(int.Parse)
//    .ToList();

//int originalCount = numbers.Count;

//for (int i = 0; i < originalCount / 2; i++)
//{
//    numbers[i] += numbers[numbers.Count - 1];
//    numbers.RemoveAt(numbers.Count - 1);
//}

//Console.WriteLine(string.Join(" ", numbers));