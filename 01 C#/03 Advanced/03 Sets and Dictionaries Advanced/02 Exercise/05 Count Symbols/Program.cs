string input = Console.ReadLine();

var charsCount = new SortedDictionary<char, int>();

foreach (char c in input)
{
    if (!charsCount.ContainsKey(c))
    {
        charsCount[c] = 0;
    }

    charsCount[c]++;
}

foreach (var kvp in charsCount)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
}