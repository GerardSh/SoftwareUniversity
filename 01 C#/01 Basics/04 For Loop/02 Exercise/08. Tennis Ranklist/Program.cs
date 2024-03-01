int numberOfTournirs = int.Parse(Console.ReadLine());
int initialPoints = int.Parse(Console.ReadLine());
double tournirsWon = 0;
double tournirsFinals = 0;
double tournirsSemiFinals = 0;
double tournirPoints = 0;

for (int i = 1; i <= numberOfTournirs; i++)
{
    string tournirResult = Console.ReadLine();

    if (tournirResult == "W")
    {
        tournirsWon += 1;
        tournirPoints += 2000;

    }
    else if (tournirResult == "F")
    {
        tournirsFinals += 1;
        tournirPoints += 1200;
    }
    else if (tournirResult == "SF")
    {
        tournirsSemiFinals += 1;
        tournirPoints += 720;
    }
}
double sumPoints = tournirPoints + initialPoints;

Console.WriteLine($"Final points: {sumPoints}");
Console.WriteLine($"Average points: {Math.Floor(tournirPoints / numberOfTournirs)}");
Console.WriteLine($"{tournirsWon / numberOfTournirs * 100:F2}%");