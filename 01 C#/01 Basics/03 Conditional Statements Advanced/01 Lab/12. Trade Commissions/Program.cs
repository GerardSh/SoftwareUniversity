string city = Console.ReadLine();
double sells = double.Parse(Console.ReadLine());
double percent = 0;
switch (city)
{
    case "Sofia":
        if (sells <= 500 && sells >= 0)
        {
            percent = 5;
        }
        else if (sells > 500 && sells <= 1000)
        {
            percent = 7;
        }
        else if (sells > 1000 && sells <= 10000)
        {
            percent = 8;
        }
        else if (sells > 10000)
        {
            percent = 12;
        }
        else
        {
            percent = sells;
        }
        break;

    case "Varna":
        if (sells <= 500 && sells >= 0)
        {
            percent = 4.5;
        }
        else if (sells > 500 && sells <= 1000)
        {
            percent = 7.5;
        }
        else if (sells > 1000 && sells <= 10000)
        {
            percent = 10;
        }
        else if (sells > 10000)
        {
            percent = 13;
        }
        else
        {
            percent = sells;
        }
        break;

    case "Plovdiv":
        if (sells <= 500 && sells >= 0)
        {
            percent = 5.5;
        }
        else if (sells > 500 && sells <= 1000)
        {
            percent = 8;
        }
        else if (sells > 1000 && sells <= 10000)
        {
            percent = 12;
        }
        else if (sells > 10000)
        {
            percent = 14.5;
        }
        else
        {
            percent = sells;
        }
        break;

    default:
        percent = -1;
        break;
}
if (percent >= 0)
{
    Console.WriteLine($"{percent * 0.01 * sells:f2}");
}
else
{
    Console.WriteLine("error");
}