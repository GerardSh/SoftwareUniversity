using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public IReadOnlyCollection<Pet> Data => data;

        public int Capacity { get; private set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name) => data.Remove(data.FirstOrDefault(x => x.Name == name));

        public Pet GetPet(string name, string owner) => data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
