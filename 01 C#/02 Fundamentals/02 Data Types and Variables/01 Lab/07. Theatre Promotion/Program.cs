string typeOfDay = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
int ticketPrice = 0;

switch (typeOfDay)
{
    case "Weekday":
        if (age >= 0 && age <= 122)
        {

            if (age <= 18)
            {
                ticketPrice = 12;
            }
            else if (age <= 64)
            {
                ticketPrice = 18;
            }
            else
            {
                ticketPrice = 12;
            }
        }
        break;
    case "Weekend":
        if (age >= 0 && age <= 122)
        {

            if (age <= 18)
            {
                ticketPrice = 15;
            }
            else if (age <= 64)
            {
                ticketPrice = 20;
            }
            else
            {
                ticketPrice = 15;
            }
        }
        break;
    default:
        if (age >= 0 && age <= 122)
        {

            if (age <= 18)
            {
                ticketPrice = 5;
            }
            else if (age <= 64)
            {
                ticketPrice = 12;
            }
            else
            {
                ticketPrice = 10;
            }
        }
        break;
}
if (ticketPrice != 0)
{

    Console.WriteLine($"{ticketPrice}$");
}
else
{
    Console.WriteLine("Error!");
}