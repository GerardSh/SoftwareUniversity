using System.Linq;
using System.Reflection;

List<string> partyGuests = Console.ReadLine()
    .Split()
    .ToList();

List<string> filtersToAdd = new List<string>();
List<string> filtersToRemove = new List<string>();

string input;

while ((input = Console.ReadLine()) != "Print")
{
    string[] elements = input
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command.Contains("Add"))
    {
        filtersToAdd.Add(elements[1] + " " + elements[2]);
    }
    else
    {
        filtersToRemove.Add(elements[1] + " " + elements[2]);
    }
}

for (int i = 0; i < filtersToAdd.Count; i++)
{
    for (int j = 0; j < filtersToRemove.Count; j++)
    {
        if (filtersToAdd[i] == filtersToRemove[j])
        {
            filtersToAdd.RemoveAt(i--);
            filtersToRemove.RemoveAt(j);

            break;
        }
    }
}

List<Predicate<string>> predicates = new List<Predicate<string>>(filtersToAdd.Count);

foreach (string filter in filtersToAdd)
{
    string[] filterElements = filter.Split();

    if (filterElements[0].Contains("Starts"))
    {
        predicates.Add(new Predicate<string>(name => name.StartsWith(filterElements[2])));
    }
    else if (filterElements[0].Contains("Ends"))
    {
        predicates.Add(new Predicate<string>(name => name.EndsWith(filterElements[2])));
    }
    else if (filterElements[0].Contains("Length"))
    {
        predicates.Add(new Predicate<string>(name => name.Length == int.Parse(filterElements[1])));
    }
    else
    {
        predicates.Add(new Predicate<string>(name => name.Contains(filterElements[1])));
    }
}

foreach (Predicate<string> predicate in predicates)
{
    partyGuests = partyGuests.Where(x => !predicate(x)).ToList();
}

Console.WriteLine(string.Join(" ", partyGuests));




//2
List<string> partyGuests = Console.ReadLine()
    .Split()
    .ToList();

List<string> filters = new List<string>();

string input;

while ((input = Console.ReadLine()) != "Print")
{
    string[] elements = input
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command.Contains("Add"))
    {
        filters.Add(elements[1] + " " + elements[2]);
    }
    else
    {
        filters.Remove(elements[1] + " " + elements[2]);
    }
}

foreach (string filter in filters)
{
    string[] filterElements = filter.Split();

    Predicate<string> predicate = name => true;

    if (filterElements[0].Contains("Starts"))
    {
        predicate = new Predicate<string>(name => name.StartsWith(filterElements[2]));
    }
    else if (filterElements[0].Contains("Ends"))
    {
        predicate = new Predicate<string>(name => name.EndsWith(filterElements[2]));
    }
    else if (filterElements[0].Contains("Length"))
    {
        predicate = new Predicate<string>(name => name.Length == int.Parse(filterElements[1]));
    }
    else
    {
        predicate = new Predicate<string>(name => name.Contains(filterElements[1]));
    }

    partyGuests = partyGuests.Where(x => !predicate(x)).ToList();
}

Console.WriteLine(string.Join(" ", partyGuests));