Action<string> printAction = x => Console.WriteLine("Sir " + x);

Console.ReadLine()
    .Split()
    .ToList()
    .ForEach(printAction);