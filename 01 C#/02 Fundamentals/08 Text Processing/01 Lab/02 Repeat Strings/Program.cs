string[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (string str in array)
{
    foreach (char c in str)
    {
        Console.Write(str);
    }
}