int greenLight = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());

Queue<string> cars = new Queue<string>();
int passedCars = 0;

string input;

while ((input = Console.ReadLine()) != "END")
{
    string currentCar = input;

    if (currentCar != "green")
    {
        cars.Enqueue(currentCar);
    }
    else
    {
        int remainingSeconds = greenLight;
        while (remainingSeconds > 0 && cars.Count > 0)
        {
            string passingCar = cars.Dequeue();
            remainingSeconds -= passingCar.Length;
            passedCars++;

            if (remainingSeconds + freeWindow < 0)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{passingCar} was hit at {passingCar[passingCar.Length - (remainingSeconds + freeWindow) * -1]}.");
                return;
            }
        }
    }
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{passedCars} total cars passed the crossroads.");