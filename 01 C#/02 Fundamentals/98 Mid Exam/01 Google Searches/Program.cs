using System.Drawing;

decimal incomeSingleSearch = decimal.Parse(Console.ReadLine());
int numberUsers = int.Parse(Console.ReadLine());

decimal totalMoney = 0;

for (int i = 1; i <= numberUsers; i++)
{
    int numberSearchesPerUser = int.Parse(Console.ReadLine());

    decimal incomeFromUser = numberSearchesPerUser * incomeSingleSearch;

    if (numberSearchesPerUser <= 1)
    {
        continue;
    }

    if (i % 3 == 0)
    {
        incomeFromUser *= 3;
    }

    if (numberSearchesPerUser > 5)
    {
        incomeFromUser *= 2;
    }

    totalMoney += incomeFromUser;
}

Console.WriteLine($"Total money earned: {totalMoney:f2}");
//09:10:23 04.04.2024