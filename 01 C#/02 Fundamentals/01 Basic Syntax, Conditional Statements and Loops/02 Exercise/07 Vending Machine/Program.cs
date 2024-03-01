string input;

double money = 0;
while ((input = Console.ReadLine()) != "Start")
{
    double currentMoney = double.Parse(input);
    if (currentMoney == 1 || currentMoney == 2 || currentMoney == 0.5 || currentMoney == 0.2 || currentMoney == 0.1)
    {
        money += currentMoney;
    }
    else
    {
        Console.WriteLine($"Cannot accept {currentMoney}");
    }
}

while ((input = Console.ReadLine()) != "End")
{
    double productPrice = 0;
    if (input == "Nuts")
    {
        productPrice = 2;

    }
    else if (input == "Water")
    {
        productPrice = 0.7;
    }
    else if (input == "Crisps")
    {
        productPrice = 1.5;
    }
    else if (input == "Soda")
    {
        productPrice = 0.8;
    }
    else if (input == "Coke")
    {
        productPrice = 1;
    }
    else
    {
        Console.WriteLine("Invalid product");
    }

    if (productPrice > 0)
    {
        if (money >= productPrice)
        {
            money -= productPrice;
            Console.WriteLine($"Purchased {input.ToLower()}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }

}
Console.WriteLine($"Change: {money:f2}");