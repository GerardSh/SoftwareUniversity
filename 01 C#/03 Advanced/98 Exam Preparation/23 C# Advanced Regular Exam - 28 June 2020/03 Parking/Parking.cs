using System.Text;

namespace Parking
{
    public class Parking
    {
        List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; private set; }

        public int Capacity { get; private set; }

        public int Count => data.Count;

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model) => data.Remove(data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));

        public Car GetLatestCar() => data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model) => data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
