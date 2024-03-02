var employeesByCompany = new Dictionary<string, List<string>>();

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] companyData = input
        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string company = companyData[0];
    string iD = companyData[1];

    if (!employeesByCompany.ContainsKey(company))
    {
        employeesByCompany[company] = new List<string>();
    }

    if (employeesByCompany[company].Contains(iD))
    {
        continue;
    }

    employeesByCompany[company].Add(iD);
}

foreach (var kvp in employeesByCompany.OrderBy(x => x.Key))
{
    Console.WriteLine(kvp.Key);

    foreach (var employee in kvp.Value)
    {
        Console.WriteLine($"-- {employee}");
    }
}