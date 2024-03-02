string product = Console.ReadLine();
int quantitiy = int.Parse(Console.ReadLine());

ProductTotalPrice(product, quantitiy);

static void ProductTotalPrice(string pro, int qua)
{
    double totalPrice = 0;

    switch (pro)
    {
        case "coffee":
            totalPrice = 1.5 * qua;
            break;
        case "water":
            totalPrice = 1 * qua;
            break;
        case "coke":
            totalPrice = 1.4 * qua;
            break;
        default:
            totalPrice = 2 * qua;
            break;
    }

    Console.WriteLine($"{totalPrice:f2}");
}