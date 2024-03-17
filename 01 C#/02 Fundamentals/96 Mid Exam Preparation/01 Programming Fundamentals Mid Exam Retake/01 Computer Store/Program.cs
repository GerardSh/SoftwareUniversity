string input;

decimal sum = 0;

while ((input = Console.ReadLine()) != "special" && input != "regular")
{
    decimal price = decimal.Parse(input);

    if (price <= 0)
    {
        Console.WriteLine("Invalid price!");
        continue;
    }

    sum += price;
}

if (sum == 0)
{
    Console.WriteLine("Invalid order!");
}
else
{
    decimal taxes = sum * 0.20m;
    decimal totalPrice = taxes + sum;

    if (input == "special")
    {
        totalPrice *= 0.9m;
    }

    Console.WriteLine($@"Congratulations you've just bought a new computer!
Price without taxes: {sum:f2}$
Taxes: {taxes:f2}$
-----------
Total price: {totalPrice:f2}$");
}