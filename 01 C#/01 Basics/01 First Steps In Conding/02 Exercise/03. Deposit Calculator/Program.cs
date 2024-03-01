double deposit = double.Parse(Console.ReadLine());
int depositTime = int.Parse(Console.ReadLine());
double yearlyPercent = double.Parse(Console.ReadLine());

Console.WriteLine(deposit + depositTime * (deposit * yearlyPercent / 100 / 12));