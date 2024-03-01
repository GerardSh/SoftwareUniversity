int hours = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());

if (minutes + 30 >= 60)
{
    if (hours == 23)
    {
        hours = 0;
    }
    else
    {
        hours++;
    }

    minutes = minutes + 30 - 60;
}
else
{
    minutes = minutes + 30;
}

Console.WriteLine($"{hours}:{minutes:d2}");