//Exam Start time 19:10
//01.Programming Book
double priceForOnePage = double.Parse(Console.ReadLine());
double priceForOneBookCover = double.Parse(Console.ReadLine());
int discount = int.Parse(Console.ReadLine());
double workPayment = double.Parse(Console.ReadLine());
int discountWholePrice = int.Parse(Console.ReadLine());

double initialPrice = priceForOnePage * 899 + priceForOneBookCover * 2;

double expensesAfterDiscountAndDesignerWork = initialPrice * ((100.0 - discount) / 100) + workPayment;

double finalExpense = expensesAfterDiscountAndDesignerWork * ((100.0 - discountWholePrice) / 100);

Console.WriteLine($"Avtonom should pay {finalExpense:f2} BGN.");
//19:22:49 24.02.2024




//02.Beer And Chips
string name = Console.ReadLine();
double budget = double.Parse(Console.ReadLine());
int beerBottles = int.Parse(Console.ReadLine());
int chipsNumber = int.Parse(Console.ReadLine());

double beerPrice = beerBottles * 1.20;
double chipsPrice = Math.Ceiling(chipsNumber * (beerPrice / 100 * 45));

double finalPrice = chipsPrice + beerPrice;

if (finalPrice <= budget)
{
    Console.WriteLine($"{name} bought a snack and has {budget - finalPrice:f2} leva left.");
}
else
{
    Console.WriteLine($"{name} needs {finalPrice - budget:f2} more leva!");
}
//19:31:13 24.02.2024




//03.Football Souvenirs
string team = Console.ReadLine();
string souvenirs = Console.ReadLine();
int boughtSouvenirs = int.Parse(Console.ReadLine());

double souvenirPrice = 0;

if (team == "Argentina")
{
    if (souvenirs == "flags")
    {
        souvenirPrice = 3.25;
    }
    else if (souvenirs == "caps")
    {
        souvenirPrice = 7.20;
    }
    else if (souvenirs == "posters")
    {
        souvenirPrice = 5.10;
    }
    else if (souvenirs == "stickers")
    {
        souvenirPrice = 1.25;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
    }
}
else if (team == "Brazil")
{
    if (souvenirs == "flags")
    {
        souvenirPrice = 4.20;
    }
    else if (souvenirs == "caps")
    {
        souvenirPrice = 8.5;
    }
    else if (souvenirs == "posters")
    {
        souvenirPrice = 5.35;
    }
    else if (souvenirs == "stickers")
    {
        souvenirPrice = 1.20;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
    }
}
else if (team == "Croatia")
{
    if (souvenirs == "flags")
    {
        souvenirPrice = 2.75;
    }
    else if (souvenirs == "caps")
    {
        souvenirPrice = 6.90;
    }
    else if (souvenirs == "posters")
    {
        souvenirPrice = 4.95;
    }
    else if (souvenirs == "stickers")
    {
        souvenirPrice = 1.10;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
    }
}
else if (team == "Denmark")
{
    if (souvenirs == "flags")
    {
        souvenirPrice = 3.10;
    }
    else if (souvenirs == "caps")
    {
        souvenirPrice = 6.50;
    }
    else if (souvenirs == "posters")
    {
        souvenirPrice = 4.80;
    }
    else if (souvenirs == "stickers")
    {
        souvenirPrice = 0.90;
    }
    else
    {
        Console.WriteLine("Invalid stock!");
    }
}
else
{
    Console.WriteLine("Invalid country!");
}

double totalCost = souvenirPrice * boughtSouvenirs;

if (totalCost > 0)
{
    Console.WriteLine($"Pepi bought {boughtSouvenirs} {souvenirs} of {team} for {totalCost:f2} lv.");
}
//19:47:10 24.02.2024




//04.Cat Food
int numberOfCats = int.Parse(Console.ReadLine());
int smallCatsGroup = 0;
int mediumCatsGroup = 0;
int hugeCatsGroup = 0;

double totalFoodEaten = 0;

for (int i = 0; i < numberOfCats; i++)
{
    double catDailyFood = double.Parse(Console.ReadLine());

    if (catDailyFood >= 100 && catDailyFood < 200)
    {
        smallCatsGroup++;
    }
    else if (catDailyFood >= 200 && catDailyFood < 300)
    {
        mediumCatsGroup++;
    }
    else if (catDailyFood >= 300 && catDailyFood < 400)
    {
        hugeCatsGroup++;
    }

    totalFoodEaten += catDailyFood;
}

double totalPriceFood = totalFoodEaten / 1000 * 12.45;

Console.WriteLine($"Group 1: {smallCatsGroup} cats.");
Console.WriteLine($"Group 2: {mediumCatsGroup} cats.");
Console.WriteLine($"Group 3: {hugeCatsGroup} cats.");
Console.WriteLine($"Price for food per day: {totalPriceFood:f2} lv.");
//20:01:24 24.02.2024




//05.Christmas Gifts
string input;

int numberOfKids = 0;
int numberOfAdults = 0;

while ((input = Console.ReadLine()) != "Christmas")
{
    int familyMemberAge = int.Parse(input);

    if (familyMemberAge <= 16)
    {
        numberOfKids++;
    }
    else
    {
        numberOfAdults++;
    }
}

int moneyForToys = 5 * numberOfKids;
int moneyForSweaters = 15 * numberOfAdults;

Console.WriteLine($"Number of adults: {numberOfAdults}");
Console.WriteLine($"Number of kids: {numberOfKids}");
Console.WriteLine($"Money for toys: {moneyForToys}");
Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
//20:09:45 24.02.2024




//06.Gold Mine
int locationNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < locationNumber; i++)
{
    double expectedHarvest = double.Parse(Console.ReadLine());
    int daysToHarvest = int.Parse(Console.ReadLine());

    double goldHarvestedSum = 0;

    for (int j = 0; j < daysToHarvest; j++)
    {
        goldHarvestedSum += double.Parse(Console.ReadLine());
    }

    double avergeGoldPerDay = goldHarvestedSum / daysToHarvest;

    if (avergeGoldPerDay >= expectedHarvest)
    {
        Console.WriteLine($"Good job! Average gold per day: {avergeGoldPerDay:f2}.");
    }
    else
    {
        Console.WriteLine($"You need {expectedHarvest - avergeGoldPerDay:f2} gold.");
    }
}
//20:23:33 24.02.2024
//Remaining time: 2 h, 46 m and 20 s