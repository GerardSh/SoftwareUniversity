List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

double timeFirstRacer = 0;
double timeSecondRacer = 0;

for (int i = 0; i < numbers.Count / 2; i++)
{
    timeFirstRacer += numbers[i];
    timeSecondRacer += numbers[numbers.Count - 1 - i];

    if (numbers[i] == 0)
    {
        timeFirstRacer *= 0.8;
    }
    if (numbers[numbers.Count - 1 - i] == 0)
    {
        timeSecondRacer *= 0.8;
    }
}

Console.WriteLine($"The winner is {(timeFirstRacer < timeSecondRacer ? "left" : "right")} with total time: {Math.Round((timeFirstRacer < timeSecondRacer ? timeFirstRacer : timeSecondRacer), 1)}");