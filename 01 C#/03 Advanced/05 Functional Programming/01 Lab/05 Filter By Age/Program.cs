int n = int.Parse(Console.ReadLine());

var people = new Dictionary<string, int>();

for (int i = 0; i < n; i++)
{
    string[] elements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string name = elements[0];
    int age = int.Parse(elements[1]);

    people[name] = age;
}

string commandFilter = Console.ReadLine();
int ageFilter = int.Parse(Console.ReadLine());
string[] filter = Console.ReadLine().Split();

if (commandFilter == "older")
{
    people = people.Where(x => x.Value >= ageFilter).ToDictionary(x => x.Key, x => x.Value);
}
else
{
    people = people.Where(x => x.Value < ageFilter).ToDictionary(x => x.Key, x => x.Value);
}

if (filter.Length > 1)
{
    foreach (var kvp in people)
    {
        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
    }
}
else if (filter[0] == "name")
{
    foreach (var kvp in people)
    {
        Console.WriteLine($"{kvp.Key}");
    }
}
else
{
    foreach (var kvp in people)
    {
        Console.WriteLine($"{kvp.Value}");
    }
}




//2
class Person
{
    public string Name { get; set; }

    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>(n);

        for (int i = 0; i < n; i++)
        {
            string[] elements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string name = elements[0];
            int age = int.Parse(elements[1]);

            people.Add(new Person()
            {
                Name = name,
                Age = age
            });
        }

        string commandFilter = Console.ReadLine();
        int ageFilter = int.Parse(Console.ReadLine());
        string[] filter = Console.ReadLine().Split();

        if (commandFilter == "older")
        {
            people = people.Where(x => x.Age >= ageFilter).ToList();
        }
        else
        {
            people = people.Where(x => x.Age < ageFilter).ToList();
        }

        if (filter.Length > 1)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
        else if (filter[0] == "name")
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}");
            }
        }
        else
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Age}");
            }
        }
    }
}