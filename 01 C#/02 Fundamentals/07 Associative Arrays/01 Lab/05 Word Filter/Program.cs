string[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(x => x.Length % 2 == 0)
    .ToArray();

foreach (var x in array)
{
    Console.WriteLine(x);
}

//2
Console.ReadLine()
    .Split()
    .Where(x => x.Length % 2 == 0)
    .ToList()
    .ForEach(x => Console.WriteLine(x));