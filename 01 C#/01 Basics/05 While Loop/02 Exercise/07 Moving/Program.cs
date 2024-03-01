int widht = int.Parse(Console.ReadLine());
int lenght = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());

double freeSpace = widht * lenght * height;

string command = Console.ReadLine();


while (command != "Done" && freeSpace > 0)
{
    int numberOfCartoons = int.Parse(command);
    freeSpace -= numberOfCartoons;

    if (freeSpace > 0)
    {
        command = Console.ReadLine();
    }
}

if (freeSpace >= 0)
{
    Console.WriteLine($"{freeSpace} Cubic meters left.");
}
else
{
    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
}