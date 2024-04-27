int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split();

Predicate<string> predicate = name => name.Length <= n;
Action<string> printName = name => Console.WriteLine(name);

names.Where(name => predicate(name))
    .ToList()
    .ForEach(printName);