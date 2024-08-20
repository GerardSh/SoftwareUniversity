using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        List<IEquipment> equipment;
        List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment ?? new List<IEquipment>();

        public ICollection<IAthlete> Athletes => athletes ?? new List<IAthlete>();

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) => this.equipment.Add(equipment);

        public void Exercise() => athletes.ForEach(x => x.Exercise());

        public string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.AppendLine($"Athletes: {(athletes.Count > 0 ? string.Join(", ", athletes.Select(x=>x.FullName)) : "No athletes")}");
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.Append($"Equipment total weight: {equipment.Sum(x => x.Weight):f2} grams");

            return sb.ToString();
        }

        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);
    }
}
