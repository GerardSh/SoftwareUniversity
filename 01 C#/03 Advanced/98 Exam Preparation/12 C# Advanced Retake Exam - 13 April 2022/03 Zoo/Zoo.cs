using System.Text;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; private set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species) => Animals.RemoveAll(x => x.Species == species);

        public List<Animal> GetAnimalsByDiet(string diet) => Animals.Where(x => x.Diet == diet).ToList();

        public Animal GetAnimalByWeight(double weight) => Animals.FirstOrDefault(x => x.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength) =>
            $"There are {Animals.Count(x => x.Length >= minimumLength && x.Length < maximumLength)} animals with a length between {minimumLength} and {maximumLength} meters.";
    }
}
