using System.Text.RegularExpressions;

double sum = 0;
string input;

while ((input = Console.ReadLine()) != "end of shift")
{
    Match matchName = Regex.Match(input, @"%(?<name>[A-Z][a-z]+)%");
    Match matchProduct = Regex.Match(input, @"<(?<product>[\w]+)>");
    Match matchCount = Regex.Match(input, @"\|(?<count>[\d]+)\|");
    Match matchPrice = Regex.Match(input, @"(?<price>[\d]+\.?\d*)\$");


    if (!matchCount.Success || !matchPrice.Success || !matchName.Success || !matchProduct.Success)
    {
        continue;
    }

    string name = matchName.Groups["name"].Value;
    string product = matchProduct.Groups["product"].Value;

    int count = int.Parse(matchCount.Groups["count"].Value);
    double price = double.Parse(matchPrice.Groups["price"].Value);

    double totalPrice = price * count;
    sum += totalPrice;

    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
}

Console.WriteLine($"Total income: {sum:f2}");




//2
using System.Text.RegularExpressions;

double sum = 0;
string input;

while ((input = Console.ReadLine()) != "end of shift")
{
    Match match = Regex.Match(input, @"\%(?<name>[A-Z][a-z]+)\%.*<(?<product>\w+)>.*\|(?<count>\d+)\|[^1-9]*(?<price>\d+\.?\d*)\$");

    if (!match.Success)
    {
        continue;
    }

    string name = match.Groups["name"].Value;
    string product = match.Groups["product"].Value;

    int count = int.Parse(match.Groups["count"].Value);
    double price = double.Parse(match.Groups["price"].Value);

    double totalPrice = price * count;
    sum += totalPrice;

    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
}

Console.WriteLine($"Total income: {sum:f2}");