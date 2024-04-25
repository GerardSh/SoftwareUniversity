int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int sum = numbers.Sum();

Console.WriteLine($"{numbers.Length}\n{numbers.Sum()}");