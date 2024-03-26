Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

int wastedLittersOfWater = 0;

while (cups.Count > 0 && bottles.Count > 0)
{
    int currentCup = cups.Dequeue() - bottles.Pop();

    if (currentCup <= 0)
    {
        wastedLittersOfWater += Math.Abs(currentCup);
    }
    else
    {
        while (bottles.Count > 0)
        {
            currentCup -= bottles.Pop();

            if (currentCup <= 0)
            {
                wastedLittersOfWater += Math.Abs(currentCup);
                break;
            }
        }
    }
}

if (cups.Count > 0)
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}
else
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}

Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");