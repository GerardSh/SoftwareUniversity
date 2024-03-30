using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    Match validBarcode = Regex.Match(input, @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+");

    if (validBarcode.Success == true)
    {
        string productGroup = string.Empty;

        MatchCollection digits = Regex.Matches(validBarcode.Value, @"\d");

        if (digits.Count > 0)
        {
            foreach (Match match in digits)
            {
                productGroup += match.Value;
            }
        }
        else
        {
            productGroup = "00";
        }

        Console.WriteLine($"Product group: {productGroup}");
    }
    else
    {
        Console.WriteLine("Invalid barcode");
    }
}




//2
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string barCode = Console.ReadLine();

    Match match = Regex.Match(barCode, @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+");

    if (!match.Success)
    {
        Console.WriteLine("Invalid barcode");
    }
    else
    {
        MatchCollection matches = Regex.Matches(barCode, @"[\d]");

        string productGroup = "00";

        if (matches.Count > 0)
        {
            productGroup = "";

            foreach (Match digit in matches)
            {
                productGroup += digit.Value;
            }
        }

        Console.WriteLine("Product group: " + productGroup);
    }
}




//3
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string barCode = Console.ReadLine();

    Match match = Regex.Match(barCode, @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+");

    if (!match.Success)
    {
        Console.WriteLine("Invalid barcode");
    }
    else
    {
        string productGroup = "";

        foreach (char c in match.Value)
        {
            if (char.IsDigit(c))
            {
                productGroup += c;
            }
        }

        if (productGroup.Length == 0)
        {
            productGroup = "00";
        }

        Console.WriteLine("Product group: " + productGroup);
    }
}