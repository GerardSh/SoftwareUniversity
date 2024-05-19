namespace ConsoleApp
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person? other)
        {
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            //Option 1
            Person person = (Person)obj;
            return Name == person.Name && Age == person.Age;

            //Option2
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}