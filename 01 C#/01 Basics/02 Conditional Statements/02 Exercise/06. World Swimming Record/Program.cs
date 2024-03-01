double record = double.Parse(Console.ReadLine());
double meters = double.Parse(Console.ReadLine());
double secondsPerMeter = double.Parse(Console.ReadLine());


// every 15m 12.5 seconds delay
double delay = Math.Floor((meters / 15)) * 12.5;
double timeNeeded = meters * secondsPerMeter + delay;
if (timeNeeded < record)
{
    Console.WriteLine($" Yes, he succeeded! The new world record is {timeNeeded:f2} seconds.");
}
else
{
    Console.WriteLine($"No, he failed! He was {timeNeeded - record:f2} seconds slower.");
}