using System.Collections.Generic;

double savings = double.Parse(Console.ReadLine());

List<int> drums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> drumsInitialQuality = new List<int>(drums);

string input;

while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
{
    int power = int.Parse(input);

    for (int i = 0; i < drums.Count; i++)
    {
        drums[i] -= power;

        if (drums[i] <= 0)
        {
            double price = drumsInitialQuality[i] * 3;

            if (savings >= price)
            {
                savings -= price;
                drums[i] = drumsInitialQuality[i];
            }
            else
            {
                drumsInitialQuality.RemoveAt(i);
                drums.RemoveAt(i--);
                continue;
            }
        }
    }
}

Console.WriteLine(string.Join(" ", drums));
Console.WriteLine($"Gabsy has {savings:f2}lv.");