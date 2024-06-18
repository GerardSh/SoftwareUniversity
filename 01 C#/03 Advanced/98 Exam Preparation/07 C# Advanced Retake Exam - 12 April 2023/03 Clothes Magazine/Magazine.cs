using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color) => Clothes.Remove(Clothes.FirstOrDefault(x => x.Color == color));

        public Cloth GetSmallestCloth()
        {
            if (Clothes.Count == 0) return null;

            return Clothes.OrderBy(x => x.Size).FirstOrDefault();
        }

        public Cloth GetCloth(string color)
        {
            if (Clothes.Count == 0) return null;

           return Clothes.FirstOrDefault(x => x.Color == color);
        }

        public int GetClothCount() => Clothes.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Type} magazine contains:");

            foreach (var item in Clothes.OrderBy(x => x.Size))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
