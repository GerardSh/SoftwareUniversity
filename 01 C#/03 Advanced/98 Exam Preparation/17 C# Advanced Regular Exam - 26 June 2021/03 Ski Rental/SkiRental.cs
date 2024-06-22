using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model) => data.Remove(data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));

        public Ski GetNewestSki()
        {
            if (data.Count > 0)
            {
                int newestSkiYear = data.Max(x => x.Year);
                return data.FirstOrDefault(x => x.Year == newestSkiYear);
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model) => data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}