using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>(capacity);
        }

        public int Capacity { get; set; }

        Dictionary<string, Shark> sharks = new Dictionary<string, Shark>();

        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;

        public void AddShark(Shark shark)
        {
            if (!sharks.ContainsKey(shark.Kind) && GetCount < Capacity)
            {
                Species.Add(shark);
                sharks[shark.Kind] = shark;
            }
        }

        public bool RemoveShark(string kind)
        {
            Species.RemoveAll(s => s.Kind == kind);

            return sharks.Remove(kind);
        }

        public string GetLargestShark()
        {
            return Species.OrderByDescending(x=>x.Length).FirstOrDefault().ToString();
        }

        public double GetAverageLength()
        {
            return Species.Average(x => x.Length);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetCount} sharks classified:");

            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}