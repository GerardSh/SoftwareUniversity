double excursionPrice = double.Parse(Console.ReadLine());
int pazel = int.Parse(Console.ReadLine());
int dolls = int.Parse(Console.ReadLine());
int bears = int.Parse(Console.ReadLine());
int minion = int.Parse(Console.ReadLine());
int trucks = int.Parse(Console.ReadLine());
int sum = pazel + dolls + bears + minion + trucks;


double pazelPrice = pazel * 2.60;
double dollsPrice = dolls * 3.0;
double bearsPrice = bears * 4.1;
double minionPrice = minion * 8.2;
double trucksPrice = trucks * 2.0;
double sumPrice = pazelPrice + dollsPrice + bearsPrice + minionPrice + trucksPrice;

if (sum >= 50)
{
    sumPrice -= sumPrice * 0.25;
    //sumPrice *= 0.75;
}
sumPrice *= 0.90;

if (sumPrice >= excursionPrice)
{
    Console.WriteLine($"Yes! {sumPrice - excursionPrice:f2} lv left.");
}
else
{
    Console.WriteLine($"Not enough money! {excursionPrice - sumPrice:f2} lv needed.");
}