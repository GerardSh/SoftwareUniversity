int width = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());
int cakeSize = width * height;
int sumPieces = 0;

string command = Console.ReadLine();

while (command != "STOP")
{
    int currentPiece = int.Parse(command);
    sumPieces += currentPiece;

    if (cakeSize - sumPieces <= 0)
    {
        break;
    }
    command = Console.ReadLine();
}

int piecesLeft = cakeSize - sumPieces;

if (piecesLeft >= 0)
{
    Console.WriteLine($"{piecesLeft} pieces are left.");
}
else
{
    Console.WriteLine($"No more cake left! You need {piecesLeft * -1} pieces more.");
}