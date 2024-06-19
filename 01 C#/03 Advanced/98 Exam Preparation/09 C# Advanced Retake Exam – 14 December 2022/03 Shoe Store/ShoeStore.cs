using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes { get; private set; }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Count < StorageCapacity)
            {
                Shoes.Add(shoe);

                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }

            return $"No more space in the storage room.";
        }

        public int RemoveShoes(string material) => Shoes.RemoveAll(x => x.Material == material);

        public List<Shoe> GetShoesByType(string type) => Shoes.Where(x => x.Type.ToLower() == type.ToLower()).ToList();

        public Shoe GetShoeBySize(double size) => Shoes.FirstOrDefault(x => x.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> filteredList = Shoes.Where(x => x.Size == size && x.Type == type).ToList();

            if (filteredList.Count > 0)
            {
                var sb = new StringBuilder();

                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var item in filteredList)
                {
                    sb.AppendLine(item.ToString());
                }

                return sb.ToString().Trim();
            }

            return "No matches found!";
        }
    }
}
