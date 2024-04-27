Func<int[], int> GetMinValue = num => num.Min();

Console.WriteLine(GetMinValue(Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray()));