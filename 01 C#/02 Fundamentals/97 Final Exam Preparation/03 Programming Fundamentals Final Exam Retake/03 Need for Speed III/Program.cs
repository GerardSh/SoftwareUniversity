using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

Dictionary<string, int[]> cars = new Dictionary<string, int[]>();

AddCars(cars, n);

string input;

while ((input = Console.ReadLine()) != "Stop")
{
    string[] commands = input
        .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    string car = commands[1];

    if (command == "Drive")
    {
        int distance = int.Parse(commands[2]);
        int fuel = int.Parse(commands[3]);

        if (fuel > cars[car][1])
        {
            Console.WriteLine("Not enough fuel to make that ride");
        }
        else
        {
            cars[car][0] += distance;
            cars[car][1] -= fuel;

            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
        }

        if (cars[car][0] >= 100000)
        {
            Console.WriteLine($"Time to sell the {car}!");

            cars.Remove(car);
        }
    }
    else if (command == "Refuel")
    {
        int fuel = int.Parse(commands[2]);

        if (fuel + cars[car][1] > 75)
        {
            int fuelRefilled = fuel - ((fuel + cars[car][1]) - 75);
            cars[car][1] = 75;

            Console.WriteLine($"{car} refueled with {fuelRefilled} liters");
        }
        else
        {
            cars[car][1] += fuel;
            Console.WriteLine($"{car} refueled with {fuel} liters");
        }
    }
    else if (command == "Revert")
    {
        int kilometters = int.Parse(commands[2]);

        if (cars[car][0] - kilometters < 10000)
        {
            cars[car][0] = 10000;
        }
        else
        {
            cars[car][0] -= kilometters;
            Console.WriteLine($"{car} mileage decreased by {kilometters} kilometers");
        }
    }
}

foreach (var car in cars)
{
    Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
}

static void AddCars(Dictionary<string, int[]> cars, int n)
{
    for (int i = 0; i < n; i++)
    {
        string[] carData = Regex.Split(Console.ReadLine(), @"\|");

        string carName = carData[0];
        int carDistance = int.Parse(carData[1]);
        int carFuel = int.Parse(carData[2]);

        cars.Add(carName, new int[] { carDistance, carFuel });
    }
}