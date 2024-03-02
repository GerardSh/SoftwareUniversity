List<int> firstHand = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> secondHand = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

while (firstHand.Count > 0 && secondHand.Count > 0)
{
    if (firstHand[0] > secondHand[0])
    {
        HandsChange(firstHand, secondHand);
    }
    else if (firstHand[0] < secondHand[0])
    {
        HandsChange(secondHand, firstHand);
    }
    else
    {
        firstHand.RemoveAt(0);
        secondHand.RemoveAt(0);
    }
}

int firstPlayer = firstHand.Sum();
int secondPlayer = secondHand.Sum();

if (firstPlayer > secondPlayer)
{
    Console.WriteLine($"First player wins! Sum: {firstPlayer}");
}
else
{
    Console.WriteLine($"Second player wins! Sum: {secondPlayer}");
}

static void HandsChange(List<int> biggerHand, List<int> smallerHand)
{
    biggerHand.Add(biggerHand[0]);
    biggerHand.Add(smallerHand[0]);
    biggerHand.RemoveAt(0);
    smallerHand.RemoveAt(0);
}
