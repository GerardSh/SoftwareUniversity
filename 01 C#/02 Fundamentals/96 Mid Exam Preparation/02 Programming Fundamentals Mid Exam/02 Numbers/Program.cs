int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

double avrg = Math.Round(GetAverage(array), 2);

Array.Sort(array);
Array.Reverse(array);

bool greaterThanAverage = false;

for (int i = 0; i < array.Length && i < 5; i++)
{
    if (array[i] > avrg)
    {
        Console.Write(array[i] + " ");
        greaterThanAverage = true;
    }
}

if (!greaterThanAverage)
{
    Console.WriteLine("No");
}

static double GetAverage(int[] array)
{
    double sum = 0;

    foreach (var item in array)
    {
        sum += item;
    }

    return sum / array.Length;
}