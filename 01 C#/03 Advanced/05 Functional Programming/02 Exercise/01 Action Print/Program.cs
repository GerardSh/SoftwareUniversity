List<string> strings = Console.ReadLine()
    .Split()
    .ToList();

Action<string> printAction = x => Console.WriteLine(x);

strings.ForEach(printAction);