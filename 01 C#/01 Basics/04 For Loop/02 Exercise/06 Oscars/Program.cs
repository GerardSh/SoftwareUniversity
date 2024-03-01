string actorsName = Console.ReadLine();
double academyPoints = double.Parse(Console.ReadLine());
int numberOfEvaluators = int.Parse(Console.ReadLine());
int n = numberOfEvaluators;
double sumPoints = academyPoints;

for (int i = 1; i <= n; i++)
{
    string nameOfEvaluator = Console.ReadLine();
    double evaluatorPoints = double.Parse(Console.ReadLine());
    sumPoints += evaluatorPoints * nameOfEvaluator.Length / 2;

    if (sumPoints > 1250.5)
    {
        Console.WriteLine($"Congratulations, {actorsName} got a nominee for leading role with {sumPoints:f1}!");
        break;
    }
}
if (sumPoints <= 1250.5)
{
    Console.WriteLine($"Sorry, {actorsName} you need {1250.5 - sumPoints:f1} more!");
}