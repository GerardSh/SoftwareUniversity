int numberOfGroups = int.Parse(Console.ReadLine());
double musala = 0;
double monblan = 0;
double kalimandjaro = 0;
double k2 = 0;
double everest = 0;
int sumPeople = 0;

for (int i = 1; i <= numberOfGroups; i++)
{
    int numberInGroup = int.Parse(Console.ReadLine());
    sumPeople += numberInGroup;

    if (numberInGroup <= 5)
    {

        musala += numberInGroup;
    }
    else if (numberInGroup <= 12)
    {

        monblan += numberInGroup;
    }
    else if (numberInGroup <= 25)
    {

        kalimandjaro += numberInGroup;
    }
    else if (numberInGroup <= 40)
    {

        k2 += numberInGroup;
    }
    else
    {
        everest += numberInGroup;
    }
}

Console.WriteLine($"{musala / sumPeople * 100:f2}%");
Console.WriteLine($"{monblan / sumPeople * 100:f2}%");
Console.WriteLine($"{kalimandjaro / sumPeople * 100:f2}%");
Console.WriteLine($"{k2 / sumPeople * 100:f2}%");
Console.WriteLine($"{everest / sumPeople * 100:f2}%");