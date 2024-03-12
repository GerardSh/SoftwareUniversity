using System.Text.RegularExpressions;

List<string> tickets = Regex.Split(Console.ReadLine(), "[, ]+").ToList();

Regex ticketRegex = new Regex(@"[@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10}");

foreach (string ticket in tickets)
{
    if (ticket.Length < 20 || ticket.Length > 20)
    {
        Console.WriteLine("invalid ticket");
        continue;
    }

    MatchCollection matchesLeft = ticketRegex.Matches(ticket.Substring(0, 10));
    MatchCollection matchesRight = ticketRegex.Matches(ticket.Substring(10));

    if (matchesLeft.Count < 1 || matchesRight.Count < 1)
    {
        Console.WriteLine($"ticket \"{ticket}\" - no match");
        continue;
    }

    int winningSequence = Math.Min(matchesLeft[0].Length, matchesRight[0].Length);
    char winningSymbol = matchesLeft[0].Value[0];

    if (winningSequence < 10)
    {
        Console.WriteLine($"ticket \"{ticket}\" - {winningSequence}{winningSymbol}");
    }
    else
    {
        Console.WriteLine($"ticket \"{ticket}\" - {winningSequence}{winningSymbol} Jackpot!");
    }
}