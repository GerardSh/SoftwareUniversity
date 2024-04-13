double[] numbers = Console.ReadLine()
    .Split()
    .Select(double.Parse)
    .ToArray();

var countByNumbers = new Dictionary<double, int>();

foreach (var number in numbers)
{
    if (!countByNumbers.ContainsKey(number))
    {
        countByNumbers.Add(number, 0);
    }

    countByNumbers[number]++;
}

foreach (var kvp in countByNumbers)
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
}