double chickenPrice = double.Parse(Console.ReadLine()) * 10.35;
double fishPrice = int.Parse(Console.ReadLine()) * 12.4;
double vegPrice = double.Parse(Console.ReadLine()) * 8.15;
double desert = (chickenPrice + fishPrice + vegPrice) * 0.2;

//desert is 20% of the total price -> 20% * 5 = 100%
Console.WriteLine(desert + desert * 5 + 2.5);