int n = int.Parse(Console.ReadLine());

var citiesAndCountriesByContinents = new Dictionary<string, Dictionary<string, List<string>>>();

for (int i = 0; i < n; i++)
{
    string[] elements = Console.ReadLine().Split();

    string continent = elements[0] + ":";
    string country = elements[1] + " ->";
    string city = elements[2];

    if (!citiesAndCountriesByContinents.ContainsKey(continent))
    {
        citiesAndCountriesByContinents[continent] = new Dictionary<string, List<string>>();
    }

    if (!citiesAndCountriesByContinents[continent].ContainsKey(country))
    {
        citiesAndCountriesByContinents[continent][country] = new List<string>();
    }

    citiesAndCountriesByContinents[continent][country].Add(city);
}

foreach (var continent in citiesAndCountriesByContinents)
{
    Console.WriteLine(continent.Key);

    foreach (var country in continent.Value)
    {
        Console.WriteLine($"  {country.Key} {string.Join(", ", country.Value)}");
    }
}