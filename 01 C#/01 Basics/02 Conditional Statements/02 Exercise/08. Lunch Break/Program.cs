string seriesName = Console.ReadLine();
int episodeDuration = int.Parse(Console.ReadLine());
int brakeDuration = int.Parse(Console.ReadLine());

double lunchTime = brakeDuration / 8d;
double relaxTime = brakeDuration / 4d;

if (episodeDuration <= brakeDuration - (lunchTime + relaxTime))
    Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(brakeDuration - (lunchTime + relaxTime) - episodeDuration)} minutes free time.");
else
    Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(episodeDuration - (brakeDuration - (lunchTime + relaxTime)))} more minutes.");