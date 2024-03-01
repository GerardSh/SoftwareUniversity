int age = int.Parse(Console.ReadLine());
double washerMachinePrice = double.Parse(Console.ReadLine());
double toysPrice = double.Parse(Console.ReadLine());

double savedMoney = 0;
double moneyFromToys = 0;
double moneySum = 0;
double moneyLeft = 0;
int count = 1;

for (int i = 1; i <= age; i++)
{
    if (i % 2 == 0)
    {
        savedMoney += 10 * count - 1;
        count++;
    }
    else
    {
        moneyFromToys += toysPrice;
    }
}
moneySum = moneyFromToys + savedMoney;
moneyLeft = moneySum - washerMachinePrice;

if (moneyLeft >= 0)
{
    Console.WriteLine($"Yes! {moneyLeft:f2}");
}
else
{
    Console.WriteLine($"No! {moneyLeft * -1:f2}");
}