Queue<string> names = new Queue<string>(Console.ReadLine().Split());
int rotations = int.Parse(Console.ReadLine());

while (names.Count > 1)
{
    for (int i = 1; i <= rotations; i++)
    {
        if (i == rotations)
        {
            Console.WriteLine($"Removed {names.Dequeue()}");
        }
        else
        {
            names.Enqueue(names.Dequeue());
        }
    }
}

Console.WriteLine("Last is " + names.Dequeue());




//2 with List
List<string> names = Console.ReadLine().Split().ToList();
int n = int.Parse(Console.ReadLine());
int index = 0;

while (names.Count > 1)
{
    for (int i = 0; i < n - 1; i++)
    {
        if (index >= names.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }

    Console.WriteLine("Removed " + names[index]);

    names.Remove(names[index]);

    if (index == names.Count)
    {
        index = 0;
    }
}

Console.WriteLine("Last is " + names[0]);