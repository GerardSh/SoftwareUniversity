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