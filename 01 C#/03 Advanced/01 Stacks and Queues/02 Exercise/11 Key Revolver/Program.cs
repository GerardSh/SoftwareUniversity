int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());
Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
int intelligenceValue = int.Parse(Console.ReadLine());

int bulletsCost = 0;
int firedBullets = 0;

while (locks.Count > 0 && bullets.Count > 0)
{
    int lockSize = locks.Peek();
    int bulletSize = bullets.Pop();
    bulletsCost += bulletPrice;

    if (lockSize >= bulletSize)
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    firedBullets++;

    if (firedBullets == gunBarrelSize)
    {
        if (bullets.Count > 0)
        {
            Console.WriteLine("Reloading!");
        }

        firedBullets = 0;
    }
}

if (locks.Count > 0)
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}
else
{
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - bulletsCost}");
}