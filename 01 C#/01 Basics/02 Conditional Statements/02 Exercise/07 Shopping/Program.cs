double budget = double.Parse(Console.ReadLine());
int videoCards = int.Parse(Console.ReadLine());
int processors = int.Parse(Console.ReadLine());
int ram = int.Parse(Console.ReadLine());

int videoCardsPrice = videoCards * 250;
double processorsPrice = processors * videoCardsPrice * 0.35;
double ramPrice = ram * videoCardsPrice * 0.1;
double totalPrice = videoCardsPrice + processorsPrice + ramPrice;

if (videoCards > processors)
{
    totalPrice *= 0.85;
}

if (totalPrice <= budget)
{
    Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva more!");
}