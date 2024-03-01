int yearlyTax = int.Parse(Console.ReadLine());
double basketballFoot = yearlyTax * (1 - 0.40);
double basketballWear = basketballFoot * (1 - 0.20);
double basketBall = basketballWear / 4;
double basketballAccessories = basketBall / 5;

Console.WriteLine(yearlyTax + basketballFoot + basketballWear + basketBall + basketballAccessories);