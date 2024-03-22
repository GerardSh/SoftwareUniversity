int amountOfFood = int.Parse(Console.ReadLine());

Queue<int> orders = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Console.WriteLine(orders.Max());

while (orders.Count > 0 && amountOfFood > 0)
{
    if (orders.Peek() <= amountOfFood)
    {
        amountOfFood -= orders.Dequeue();
    }
    else
    {
        break;
    }
}

if (orders.Count > 0)
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
else
{
    Console.WriteLine("Orders complete");
}