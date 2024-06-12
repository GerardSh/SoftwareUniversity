namespace WildFarm
{
    public class Program
    {
        public static void Main()
        {
            var foodMap = new Dictionary<string, SortedSet<string>>()
            {
                {"Vegetable", new SortedSet<string>(){"Hen", "Mice", "Cat" }},
                {"Fruit", new SortedSet<string>(){"Hen", "Mouse"}},
                {"Meat", new SortedSet<string>(){"Hen", "Cat", "Tiger", "Dog", "Owl"}},
                {"Seeds", new SortedSet<string>(){"Hen"}},
            };

            var animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = CreateAnimal(animalData);

                animals.Add(animal);

                string[] foodData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Food food = food = CreateFood(foodData);

                Console.WriteLine(animal?.ProduceSound());

                string animalType = animalData[0];
                string foodType = foodData[0];

                if (foodMap[foodType].Contains(animalType))
                {
                    animal.Weight = food.Quantity;
                    animal.FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animalType} does not eat {foodType}!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Food CreateFood(string[] foodData)
        {
            string foodType = foodData[0];
            int quantity = int.Parse(foodData[1]);

            if (foodType == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                return new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                return new Seeds(quantity);
            }

            return null;
        }

        private static Animal CreateAnimal(string[] animalData)
        {
            string animalType = animalData[0];
            string name = animalData[1];
            double weigth = double.Parse(animalData[2]);

            if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalData[3]);
                return new Owl(name, weigth, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalData[3]);
                return new Hen(name, weigth, wingSize);
            }
            else
            {
                string livingRegion = animalData[3];

                if (animalType == "Mouse")
                {
                    return new Mouse(name, weigth, livingRegion);
                }
                else if (animalType == "Dog")
                {
                    return new Dog(name, weigth, livingRegion);
                }
                else
                {
                    string breed = animalData[4];

                    if (animalType == "Cat")
                    {
                        return new Cat(name, weigth, livingRegion, breed);
                    }
                    else if (animalType == "Tiger")
                    {
                        return new Tiger(name, weigth, livingRegion, breed);
                    }
                }
            }

            return null;
        }
    }
}