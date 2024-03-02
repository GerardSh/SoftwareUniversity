namespace ConsoleApp
{
    class Engine
    {
        public int Speed { get; set; }

        public int Power { get; set; }
    }

    class Cargo
    {
        public int Weight { get; set; }

        public string Type { get; set; } = "";
    }

    class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; } = new Engine();

        public Cargo Cargo { get; set; } = new Cargo();
    }

    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split();

                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];

                cars.Add(new Car()
                {
                    Model = model,
                    Cargo = new Cargo()
                    {
                        Type = cargoType,
                        Weight = cargoWeight,
                    },
                    Engine = new Engine()
                    {
                        Power = enginePower,
                        Speed = engineSpeed
                    }
                });
            }

            string input = Console.ReadLine();

            foreach (Car car in cars.Where(c => c.Cargo.Type == input && input == "fragile" ? c.Cargo.Weight < 1000 : c.Engine.Power > 250).ToList())
            {
                Console.WriteLine(car.Model);
            }


        }
    }
}