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




//2
public class PetrolPump
{
    public PetrolPump(int fuel, int distance)
    {
        this.Fuel = fuel;
        this.Distance = distance;
    }

    public int Fuel { get; set; }
    public int Distance { get; set; }
}

class Program
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        Queue<PetrolPump> pumps = new Queue<PetrolPump>();

        for (int i = 0; i < n; i++)
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            pumps.Enqueue(new PetrolPump(elements[0], elements[1]));
        }

        int index = 0;

        for (int i = 0; i <= n; i++)
        {
            int fuel = 0;

            foreach (PetrolPump pump in pumps)
            {
                fuel += pump.Fuel - pump.Distance;

                if (fuel < 0)
                {
                    pumps.Enqueue(pumps.Dequeue());
                    break;
                }
            }

            if (fuel >= 0)
            {
                index = i;
                break;
            }
            else if (i == pumps.Count - 1)
            {
                index = -1;
                break;
            }
        }

        Console.WriteLine(index);
    }
}