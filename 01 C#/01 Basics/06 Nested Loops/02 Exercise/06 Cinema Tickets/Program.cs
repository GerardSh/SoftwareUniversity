string movieName = Console.ReadLine();
int standard = 0;
int student = 0;
int kid = 0;
int totalTicket = 0;

while (movieName != "Finish")
{
    int freeSpaces = int.Parse(Console.ReadLine());
    int initialFreeSpaces = freeSpaces;
    string ticketType = Console.ReadLine();

    while (freeSpaces > 0 && ticketType != "End")
    {

        if (ticketType == "standard")
        {
            standard++;
        }
        else if (ticketType == "kid")
        {
            kid++;
        }
        else if (ticketType == "student")
        {
            student++;
        }
        freeSpaces--;
        if (freeSpaces > 0)
            ticketType = Console.ReadLine();
    }

    int usedSpaces = initialFreeSpaces - freeSpaces;
    totalTicket += (usedSpaces);

    Console.WriteLine($"{movieName} - {100.00 * usedSpaces / initialFreeSpaces:f2}% full.");

    movieName = Console.ReadLine();
}

Console.WriteLine($"Total tickets: {totalTicket}");
Console.WriteLine($"{100.00 * student / totalTicket:f2}% student tickets.");
Console.WriteLine($"{100.00 * standard / totalTicket:f2}% standard tickets.");
Console.WriteLine($"{100.00 * kid / totalTicket:f2}% kids tickets.");




//2
string movieName = Console.ReadLine();

int student = 0;
int standard = 0;
int kids = 0;
int totalTicketsBought = 0;


while (movieName != "Finish")
{
    int freeSpaces = int.Parse(Console.ReadLine());
    string ticketType = Console.ReadLine();
    int usedSpaces = 0;

    while (ticketType != "End")
    {
        if (ticketType == "student")
        {
            student++;
        }
        else if (ticketType == "standard")
        {
            standard++;
        }
        else if (ticketType == "kid")
        {
            kids++;
        }
        totalTicketsBought++;
        usedSpaces++;

        if (usedSpaces == freeSpaces)
        {
            break;
        }

        ticketType = Console.ReadLine();
    }

    Console.WriteLine($"{movieName} - {100.00 * usedSpaces / freeSpaces:f2}% full.");

    movieName = Console.ReadLine();
}

Console.WriteLine($"Total tickets: {totalTicketsBought}");
Console.WriteLine($"{100.00 * student / totalTicketsBought:f2}% student tickets.");
Console.WriteLine($"{100.00 * standard / totalTicketsBought:f2}% standard tickets.");
Console.WriteLine($"{100.00 * kids / totalTicketsBought:f2}% kids tickets.");