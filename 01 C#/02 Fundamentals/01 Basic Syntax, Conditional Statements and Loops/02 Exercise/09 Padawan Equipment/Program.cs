double budget = double.Parse(Console.ReadLine());
int studentsCount = int.Parse(Console.ReadLine());
double lighsaberPrice = double.Parse(Console.ReadLine());
double robesPrice = double.Parse(Console.ReadLine());
double beltsPrice = double.Parse(Console.ReadLine());


double lightsaberPriceTotal = lighsaberPrice * (Math.Ceiling(studentsCount * 1.1));
double robesPriceTotal = robesPrice * studentsCount;
double beltsPriceTotal = beltsPrice * (studentsCount - studentsCount / 6);
double totalCost = lightsaberPriceTotal + robesPriceTotal + beltsPriceTotal;

if (budget >= totalCost)
{
    Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
}
else
{
    Console.WriteLine($"John will need {totalCost - budget:f2}lv more.");
}