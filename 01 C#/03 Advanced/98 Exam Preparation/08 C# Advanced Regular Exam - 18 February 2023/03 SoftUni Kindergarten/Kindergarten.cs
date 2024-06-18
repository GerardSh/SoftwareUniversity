using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName) => Registry.Remove(Registry.FirstOrDefault(x => $"{x.FirstName} {x.LastName}" == childFullName));

        public Child GetChild(string childFullName) => Registry.FirstOrDefault(x => $"{x.FirstName} {x.LastName}" == childFullName);

        public string RegistryReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry.OrderByDescending(x=>x.Age).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
