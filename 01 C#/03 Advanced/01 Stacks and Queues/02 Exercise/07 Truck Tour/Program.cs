int n = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < n; i++)
{
    int[] elements = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    pumps.Enqueue(new int[] { elements[0], elements[1] });
}

Queue<int[]> pumpsOriginal = new Queue<int[]>(pumps);
int index = 0;
for (int i = 0; i < n; i++)
{
    int remainingFuel = pumps.Peek()[0] - pumps.Peek()[1];

    if (remainingFuel >= 0)
    {
        pumps.Dequeue();

        index = i;

        while (pumps.Count > 0)
        {
            remainingFuel += pumps.Peek()[0] - pumps.Peek()[1];

            if (remainingFuel >= 0)
            {
                pumps.Dequeue();
            }
            else
            {
                pumps = new Queue<int[]>(pumpsOriginal);

                for (int j = 0; j <= i; j++)
                {
                    pumps.Enqueue(pumps.Dequeue());
                }
                break;
            }
        }

        if (pumps.Count == 0)
        {
            break;
        }

        if (i == n - 1)
        {
            index = -1;
        }
    }
    else
    {
        pumps.Enqueue(pumps.Dequeue());
    }
}

Console.WriteLine(index);