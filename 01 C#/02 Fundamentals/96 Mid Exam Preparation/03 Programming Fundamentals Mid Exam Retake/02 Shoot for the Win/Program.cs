int[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int count = 0;

string input;

while ((input = Console.ReadLine()) != "End")
{
    int index = int.Parse(input);
    int tempValue = 0;

    if (index >= 0 && index < array.Length)
    {
        if (array[index] == -1)
        {
            continue;
        }

        tempValue = array[index];
        array[index] = -1;
        count++;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == -1)
            {
                continue;
            }

            if (array[i] > tempValue)
            {
                array[i] -= tempValue;
            }
            else
            {
                array[i] += tempValue;
            }
        }
    }
}

Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", array)}");




//2
int[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int count = 0;

string input;

while ((input = Console.ReadLine()) != "End")
{
    int index = int.Parse(input);
    int tempValue = 0;

    if (index >= 0 && index < array.Length)
    {
        if (array[index] == -1)
        {
            continue;
        }

        tempValue = array[index];
        array[index] = -1;
        count++;

        array = array.Select(x =>
        {
            if (x == -1)
            {
                return x;
            }
            if (x > tempValue)
            {
                return x -= tempValue;
            }
            else
            {
                return x += tempValue;
            }
        }).ToArray();
    }
}

Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", array)}");