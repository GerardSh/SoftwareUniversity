using System.Xml.Linq;

List<string> elementSequence = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

int movesCount = 1;

string input;

while ((input = Console.ReadLine()) != "end")
{
    string[] indexes = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int indexOne = int.Parse(indexes[0]);
    int indexTwo = int.Parse(indexes[1]);

    if (indexOne == indexTwo || indexOne < 0 || indexOne >= elementSequence.Count || indexTwo < 0 || indexTwo >= elementSequence.Count)
    {
        int indexHalf = elementSequence.Count / 2;

        elementSequence.Insert(indexHalf, $"-{movesCount}a");
        elementSequence.Insert(indexHalf, $"-{movesCount}a");

        Console.WriteLine("Invalid input! Adding additional elements to the board");
    }
    else if (elementSequence[indexOne] == elementSequence[indexTwo])
    {
        Console.WriteLine($"Congrats! You have found matching elements - {elementSequence[indexOne]}!");

        elementSequence.RemoveAt(Math.Max(indexOne, indexTwo));
        elementSequence.RemoveAt(Math.Min(indexOne, indexTwo));

        if (elementSequence.Count == 0)
        {
            Console.WriteLine($"You have won in {movesCount} turns!");
            break;
        }
    }
    else if (elementSequence[indexOne] != elementSequence[indexTwo])
    {
        Console.WriteLine("Try again!");
    }

    movesCount++;
}

if (elementSequence.Count > 0)
{
    Console.WriteLine("Sorry you lose :(");
    Console.WriteLine(string.Join(" ", elementSequence));
}