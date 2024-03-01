double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string vacationLocation = "";

if (budget <= 100)
{
    vacationLocation = "Bulgaria";
    if (season == "summer")
    {
        budget *= 0.3;
    }
    else
    {
        budget *= 0.7;
    }
}
else if (budget <= 1000)
{
    vacationLocation = "Balkans";
    if (season == "summer")
    {
        budget *= 0.4;
    }
    else
    {
        budget *= 0.8;
    }
}
else
{
    vacationLocation = "Europe";

    budget *= 0.9;

}

string vacationPlace = "";

if (season == "summer" && vacationLocation != "Europe")
{
    vacationPlace = "Camp";
}
else
{
    vacationPlace = "Hotel";
}

Console.WriteLine($"Somewhere in {vacationLocation}");
Console.WriteLine($"{vacationPlace} - {budget:f2}");