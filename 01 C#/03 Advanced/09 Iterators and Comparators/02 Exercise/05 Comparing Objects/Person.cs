namespace ConsoleApp
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person? other)
        {
            //Option 1
            int result = Name.CompareTo(other.Name);

            if (result == 1)
            {
                return 1;
            }
            else if (result == -1)
            {
                return -1;
            }

            if (Age > other.Age)
            {
                return 1;
            }
            else if (Age < other.Age)
            {
                return -1;
            }

            return Town.CompareTo(other.Town);

            //Option 2
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age)
            }

            if (result == 0)
            {
                result = Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
