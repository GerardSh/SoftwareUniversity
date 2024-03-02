List<int> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).OrderByDescending(x => x).ToList();

//if (list.Count > 3)
//{
//    list.RemoveRange(3, list.Count - 3);
//}

Console.WriteLine(string.Join(" ", list.Skip()));