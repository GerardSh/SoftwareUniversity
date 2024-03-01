int days = int.Parse(Console.ReadLine());
string roomType = Console.ReadLine();
string rating = Console.ReadLine();
int nights = days - 1;
double discount = 1;
double price = 0;

if (roomType == "apartment")
{
    price = 25;
    if (nights < 10)
    {
        discount *= 0.7;
    }
    else if (nights <= 15)
    {
        discount *= 0.65;
    }
    else if (nights > 15)
    {
        discount *= 0.5;
    }
}
else if (roomType == "president apartment")
{
    price = 35;
    if (nights < 10)
    {
        discount *= 0.9;
    }
    else if (nights <= 15)
    {
        discount *= 0.85;
    }
    else if (nights > 15)
    {
        discount *= 0.8;
    }
}
else
{
    price = 18;
}
double priceTotal = nights * price * discount;

Console.WriteLine($"{priceTotal * (rating == "positive" ? 1.25 : 0.9):f2}");