namespace DefiningClasses
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int endingePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];

                Engine engine = new Engine(engineSpeed, endingePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire[] tires = new Tire[4];
                int count = 0;

                for (int j = 5; j < carData.Length; j += 2)
                {
                    double tirPressure = double.Parse(carData[j]);
                    int tireAge = int.Parse(carData[j + 1]);

                    tires[count++] = new Tire(tireAge, tirPressure);
                }

                cars.Add(new Car(model, engine, cargo, tires));
            }

            var filteredCars = new List<Car>();

            if (Console.ReadLine() == "fragile")
            {
                //1
                //filteredCars = cars.Where(car => car.Cargo.Type == "fragile"
                //&& (car.Tires[0].Pressure < 1 || car.Tires[1].Pressure < 1 || car.Tires[2].Pressure < 1 || car.Tires[3].Pressure < 1)).ToList();

                //2
                filteredCars = cars.Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(t => t.Pressure < 1)).ToList();
            }
            else
            {
                filteredCars = cars.Where(car => car.Cargo.Type == "flammable"
                && car.Engine.Power > 250).ToList();
            }

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}