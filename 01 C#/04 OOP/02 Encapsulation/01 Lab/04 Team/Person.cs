namespace PersonsInfo
{
    public class Person
    {
        private const int SalaryIncreaseAge = 30;
        private const int MinSymbols = 3;
        private const int MinAge = 1;
        private const int MinSalary = 460;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get => firstName; 
            
            private set
            {
                if (value.Length < MinSymbols)
                {
                   throw new ArgumentException($"First name cannot contain fewer than {MinSymbols} symbols!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName; 
            
            private set
            {
                if (value.Length < MinSymbols)
                {
                    throw new ArgumentException($"Last name cannot contain fewer than {MinSymbols} symbols!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get => age; 
            
            private set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get => salary; 
            
            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }

                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < SalaryIncreaseAge)
            {
                percentage /= 2;
            }

            percentage += 100;
            percentage /= 100;
            Salary *= percentage;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
