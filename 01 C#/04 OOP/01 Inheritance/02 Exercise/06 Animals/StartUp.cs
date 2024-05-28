using System.Reflection;
using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "Beast")
            {
                string animalType = input;

                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (elements.Length != 3)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string name = elements[0];
                int age;

                if (!int.TryParse(elements[1], out age) || age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string gender = elements[2];

                if (gender != "Female" && gender != "Male")
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }           

                if (animalType == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    PrintAnimalData(dog);
                }
                else if (animalType == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    PrintAnimalData(cat);
                }
                else if (animalType == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    PrintAnimalData(frog);
                }
                else if (animalType == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    PrintAnimalData(kitten);
                }
                else if (animalType == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    PrintAnimalData(tomcat);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        public static void PrintAnimalData(Animal animal)
        {
            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            Console.WriteLine(animal.ProduceSound());
        }
    }
}
