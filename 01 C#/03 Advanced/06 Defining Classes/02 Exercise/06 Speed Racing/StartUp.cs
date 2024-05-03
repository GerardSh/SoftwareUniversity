namespace DefiningClasses
{
    public class StartUp
    {
        public static List<Car> Cars { get; set; } = new List<Car>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var carModel = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionPerKilometer = double.Parse(carData[2]);

               Cars.Add(new Car(carModel, fuelAmount, fuelConsumptionPerKilometer));
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = elements[1];
                double distance = double.Parse(elements[2]);

                Car car = Cars.FirstOrDefault(x => x.Model == carModel);

                Car.Drive(car, distance);
            }

            foreach (var car in Cars) { Console.WriteLine(car); }          
        }
    }
}