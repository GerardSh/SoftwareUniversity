using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            RealEstates = new List<RealEstate>();
        }

        public int Capacity { get; set; }

        public List<RealEstate> RealEstates { get; private set; }

        public int Count => RealEstates.Count;

        public void AddRealEstate(RealEstate realEstate)
        {
            RealEstate realEstate2 = RealEstates.FirstOrDefault(x => x.Address == realEstate.Address);

            if (Count < Capacity && realEstate2 == null)
            {
                RealEstates.Add(realEstate);
            }
        }

        public bool RemoveRealEstate(string address) => RealEstates.Remove(RealEstates.FirstOrDefault(x => x.Address == address));

        public List<RealEstate> GetRealEstates(string postalCode) => RealEstates.Where(x => x.PostalCode == postalCode).ToList();

        public RealEstate GetCheapest() => RealEstates.OrderBy(x => x.Price).FirstOrDefault();

        public double GetLargest() => RealEstates.OrderByDescending(x => x.Size).FirstOrDefault().Size;

        public string EstateReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Real estates available:");

            foreach (var item in RealEstates)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
