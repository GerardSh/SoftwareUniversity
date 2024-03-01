int lostGames = int.Parse(Console.ReadLine());
double headsetPrice = double.Parse(Console.ReadLine());
double mousePrice = double.Parse(Console.ReadLine());
double keyboardPrice = double.Parse(Console.ReadLine());
double displayPrice = double.Parse(Console.ReadLine());

int brokenHeadset = lostGames / 2;
int brokenMouse = lostGames / 3;
int brokenKeyboard = lostGames / 6;
int brokenDisplay = lostGames / 12;

double rageExpenses = (brokenHeadset * headsetPrice + brokenMouse * mousePrice + brokenKeyboard * keyboardPrice + brokenDisplay * displayPrice);

Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");