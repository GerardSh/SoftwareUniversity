namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var enginesByModel = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineData[0];
                int enginePower = int.Parse(engineData[1]);
                int engineDisplacement = -1;
                string engineEfficiency = null;

                if (engineData.Length > 2)
                {
                    if (!char.IsDigit(engineData[2][0]))
                    {
                        engineEfficiency = engineData[2];
                    }
                    else
                    {
                        engineDisplacement = int.Parse(engineData[2]);
                    }
                }

                if (engineData.Length > 3)
                {
                    engineDisplacement = int.Parse(engineData[2]);
                    engineEfficiency = engineData[3];
                }

                if (!enginesByModel.ContainsKey(engineModel))
                {
                    enginesByModel[engineModel] = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                }
            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carData[0];
                string carEngineModel = carData[1];
                int weight = -1;
                string color = null;

                if (carData.Length > 2)
                {
                    if (!char.IsDigit(carData[2][0]))
                    {
                        color = carData[2];
                    }
                    else
                    {
                        weight = int.Parse(carData[2]);
                    }
                }

                if (carData.Length > 3)
                {
                    weight = int.Parse(carData[2]);
                    color = carData[3];
                }

                Car car = new Car(carModel, enginesByModel[carEngineModel], weight, color);

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.Write($"    Displacement: ");

                if (car.Engine.Displacement != -1)
                {
                    Console.WriteLine(car.Engine.Displacement);
                }
                else
                {
                    Console.WriteLine("n/a");
                }

                Console.Write($"    Efficiency: ");

                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine(car.Engine.Efficiency);
                }
                else
                {
                    Console.WriteLine("n/a");
                }

                Console.Write("  Weight: ");

                if (car.Weight != -1)
                {
                    Console.WriteLine(car.Weight);
                }
                else
                {
                    Console.WriteLine("n/a");
                }

                Console.Write("  Color: ");

                if (car.Color != null)
                {
                    Console.WriteLine(car.Color);
                }
                else
                {
                    Console.WriteLine("n/a");
                }
            }
        }
    }
}