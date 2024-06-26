﻿namespace PersonsInfo
{
    public class Person
    {
        private const int SalaryIncreaseAge = 30;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public decimal Salary { get; private set; }

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
