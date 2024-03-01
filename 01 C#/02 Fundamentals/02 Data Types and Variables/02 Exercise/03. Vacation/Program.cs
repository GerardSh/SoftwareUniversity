int number = int.Parse(Console.ReadLine());
string type = Console.ReadLine();
string day = Console.ReadLine();
double price = 0;
double discount = 1;

switch (type)
{
    case "Students":
        switch (day)
        {
            case "Friday":
                price = 8.45;
                break;
            case "Saturday":
                price = 9.80;
                break;
            case "Sunday":
                price = 10.46;
                break;
        }

        if (number >= 30)
        {
            discount = 0.85;
        }

        break;
    case "Business":
        switch (day)
        {
            case "Friday":
                price = 10.90;
                break;
            case "Saturday":
                price = 15.60;
                break;
            case "Sunday":
                price = 16;
                break;
        }

        if (number >= 100)
        {
            number -= 10;
        }

        break;
    case "Regular":
        switch (day)
        {
            case "Friday":
                price = 15;
                break;
            case "Saturday":
                price = 20;
                break;
            case "Sunday":
                price = 22.50;
                break;
        }
        break;
        if (number >= 10 && number <= 20)
        {
            discount = 0.95;
        }
}

double finalPrice = price * number * discount;

Console.WriteLine($"Total price: {finalPrice:f2}");