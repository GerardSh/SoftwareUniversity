Stack<int> clothBox = new Stack<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

int rackCapacity = int.Parse(Console.ReadLine());
int currentRackSpace = 0;
int racksUsed = 0;

if (rackCapacity == 0)
{
    racksUsed = 0;
    return;
}
while (clothBox.Count > 0)
{
    currentRackSpace += clothBox.Peek();

    if (currentRackSpace > rackCapacity)
    {
        racksUsed++;
        currentRackSpace = clothBox.Pop();

        if (clothBox.Count == 0)
        {
            racksUsed++;
        }
    }
    else if (currentRackSpace == rackCapacity)
    {
        racksUsed++;
        currentRackSpace = 0;
        clothBox.Pop();
    }
    else
    {
        clothBox.Pop();

        if (clothBox.Count == 0)
        {
            racksUsed++;
        }
    }
}

Console.WriteLine(racksUsed);