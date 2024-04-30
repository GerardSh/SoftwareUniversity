namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string input;

            List<Tire[]> tires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tiresSet = new Tire[4];

                int count = 0;

                for (int i = 0; i < elements.Length - 1; i += 2)
                {
                    int year = int.Parse(elements[i]);
                    double pressure = double.Parse(elements[i + 1]);

                    tiresSet[count++] = new Tire(year, pressure);
                }

                tires.Add(tiresSet);
            }

            List<Engine> engines = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(elements[0]);
                double cubicCapacity = double.Parse(elements[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = elements[0];
                string model = elements[1];
                int year = int.Parse(elements[2]);
                double fuelQuantity = double.Parse(elements[3]);
                double fueConsumption = double.Parse(elements[4]);
                int engineIndex = int.Parse(elements[5]);
                int tiredIndex = int.Parse(elements[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fueConsumption, engines[engineIndex], tires[tiredIndex]));
            }

            List<Car> specialCars = new List<Car>();

            foreach (Car car in cars)
            {
                double tirePressureSum = car.Tires.Sum(x => x.Pressure);

                if (car.Engine.HorsePower > 330 && car.Year >= 2017 && tirePressureSum >= 9 && tirePressureSum <= 10)
                {
                    car.Drive(20);
                    specialCars.Add(car);
                }
            }

            foreach (Car car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}