string month = Console.ReadLine();
int vacationDays = int.Parse(Console.ReadLine());
double apartmentPrice = 0;
double studioPrice = 0;
double discount = 1;


if (month == "May" || month == "October")
{
    studioPrice = 50;
    apartmentPrice = 65;
    //calculating discount for studio
    if (vacationDays > 7 && vacationDays <= 14)
    {
        discount *= 0.95;
    }
    else if (vacationDays > 14)
    {
        discount *= 0.70;
    }
}
else if (month == "June" || month == "September")
{
    studioPrice = 75.2;
    apartmentPrice = 68.7;
    //calculating discount for studio
    if (vacationDays > 14)
    {
        discount *= 0.8;
    }
}
else
{
    studioPrice = 76;
    apartmentPrice = 77;
}

Console.WriteLine($"Apartment: {apartmentPrice * vacationDays * (vacationDays > 14 ? 0.90 : 1):f2} lv.");
Console.WriteLine($"Studio: {studioPrice * vacationDays * discount:f2} lv.");