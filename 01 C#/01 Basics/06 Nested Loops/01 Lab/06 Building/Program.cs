int floors = int.Parse(Console.ReadLine());
int apartments = int.Parse(Console.ReadLine());

for (int i = floors; i >= 1; i--)
{
    for (int j = 0; j < apartments; j++)
    {
        if (i == floors && j < apartments - 1)
        {
            Console.Write($"L{i}{j} ");
        }
        else if (i == floors && j == apartments - 1)
        {
            Console.Write($"L{i}{j}");
        }
        else if (i % 2 == 0 && j < apartments - 1)
        {
            Console.Write($"O{i}{j} ");
        }
        else if (i % 2 == 0 && j == apartments - 1)
        {
            Console.Write($"O{i}{j}");
        }
        else if (i % 2 == 1 && j < apartments - 1)
        {
            Console.Write($"A{i}{j} ");
        }
        else if (i % 2 == 1 && j == apartments - 1)
        {
            Console.Write($"A{i}{j}");
        }
    }
    if (i != 1)
    {
        Console.WriteLine();
    }

}