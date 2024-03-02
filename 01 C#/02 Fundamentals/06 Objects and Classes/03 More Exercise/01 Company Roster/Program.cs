using System.ComponentModel;

namespace ConsoleApp
{
    class Department
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

    }

    class Employee
    {
        public string Name { get; set; }

        public double Salary { get; set; }

    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            List<Department> departmentList = new List<Department>(n);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string employeeName = input[0];
                string employeeSalary = input[1];
                string department = input[2];

                Department dep = departmentList.FirstOrDefault(x => x.Name == department);


                if (dep == null)
                {
                    dep = new Department() { Name = department, Employees = new List<Employee>() };
                    departmentList.Add(dep);
                }

                dep.Employees.Add(new Employee()
                {
                    Name = employeeName,
                    Salary = double.Parse(employeeSalary)
                });
            }


            string bestTeam = "";
            double highestSalary = 0;
            double averageSalary = 0;

            foreach (Department dep in departmentList)
            {
                double salarySum = 0;

                foreach (Employee emp in dep.Employees)
                {
                    salarySum += emp.Salary;
                }

                if (salarySum > highestSalary)
                {
                    highestSalary = salarySum;
                    bestTeam = dep.Name;
                    averageSalary = highestSalary / dep.Employees.Count;
                }
            }



            Console.WriteLine($"Highest Average Salary: {bestTeam}");

            Department getBest = departmentList.First(x => x.Name == bestTeam);

            getBest.Employees = getBest.Employees.OrderByDescending(x => x.Salary).ToList();


            foreach (Employee emp in getBest.Employees)
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:f2}");
            }


        }
    }
}

////2 without classes
//namespace ConsoleApp
//{
//    class Program
//    {
//        static void Main()
//        {
//            int n = int.Parse(Console.ReadLine());

//            List<string> allEmployees = new List<string>();

//            for (int i = 0; i < n; i++)
//            {
//                string input = Console.ReadLine();

//                allEmployees.Add(input);
//            }

//            List<List<string>> departments = new List<List<string>>();

//            foreach (string input in allEmployees)
//            {
//                departments.Add(input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
//            }


//            for (int i = 0; i < departments.Count - 1; i++)
//            {
//                for (int j = i + 1; j < departments.Count; j++)
//                {
//                    if (departments[i][departments[i].Count - 1] == departments[j][2])
//                    {
//                        departments[i].Insert(0, departments[j][1]);
//                        departments[i].Insert(0, departments[j][0]);
//                        departments.RemoveAt(j--);
//                    }
//                }
//            }

//            double highestAvrSalary = 0;

//            List<string> bestTeam = new List<string>();

//            foreach (List<string> department in departments)
//            {
//                double salarySum = 0;

//                for (int i = 1; i < department.Count; i += 2)
//                {
//                    salarySum += double.Parse(department[i]);
//                }

//                double highestAvrSalaryTemp = salarySum / (department.Count / 2);

//                if (highestAvrSalaryTemp > highestAvrSalary)
//                {
//                    highestAvrSalary = highestAvrSalaryTemp;
//                    bestTeam = department;
//                }
//            }

//            for (int i = bestTeam.Count - 2; i >= 1; i -= 2)
//            {
//                for (int j = i - 2; j >= 1; j -= 2)
//                {
//                    if (double.Parse(bestTeam[i]) > double.Parse(bestTeam[j]))
//                    {
//                        string temp = bestTeam[j];

//                        bestTeam[j] = bestTeam[i];
//                        bestTeam[i] = temp;
//                        temp = bestTeam[j - 1];
//                        bestTeam[j - 1] = bestTeam[i - 1];
//                        bestTeam[i - 1] = temp;
//                    }
//                }
//            }

//            Console.WriteLine("Highest Average Salary: " + bestTeam[bestTeam.Count - 1]);

//            for (int i = 0; i < bestTeam.Count - 1; i += 2)
//            {

//                Console.Write(bestTeam[i] + " " + $"{double.Parse(bestTeam[i + 1]):f2}");
//                Console.WriteLine();

//            }

//        }
//    }
//}

////3

//class Department
//{
//    public Department(string department, decimal salary, string empName)
//    {
//        Salaries = salary;
//        Name = department;
//        Members = new List<Employee>()
//        {
//            new Employee(empName, salary)
//        };
//    }
//    public string Name { get; set; }

//    public List<Employee> Members { get; set; }

//    public decimal Salaries { get; set; }
//}

//class Employee
//{
//    public Employee(string name, decimal salary)
//    {
//        Name = name;
//        Salary = salary;
//    }
//    public string Name { get; set; }

//    public decimal Salary { get; set; }
//}

//class Program
//{
//    public static void Main()
//    {
//        List<Department> departments = new List<Department>();

//        int n = int.Parse(Console.ReadLine());


//        for (int i = 0; i < n; i++)
//        {

//            string[] employeeData = Console.ReadLine().Split();

//            string name = employeeData[0];
//            decimal salary = decimal.Parse(employeeData[1]);
//            string department = employeeData[2];

//            Department currentDep = departments.FirstOrDefault(x => x.Name == department);

//            if (currentDep == null)
//            {
//                departments.Add(new Department(department, salary, name));
//            }
//            else
//            {
//                currentDep.Members.Add(new Employee(name, salary));
//                currentDep.Salaries += salary;
//            }
//        }

//        Department bestDep = departments.OrderByDescending(x => x.Salaries / x.Members.Count).First();
//        bestDep.Members = bestDep.Members.OrderByDescending(x => x.Salary).ToList();

//        Console.WriteLine("Highest Average Salary: " + bestDep.Name);

//        foreach (Employee employee in bestDep.Members)
//        {
//            Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
//        }
//    }
//}

////4 Vasko

//class Department
//{
//    public Department(string department)
//    {
//        Name = department;
//        Members = new List<Employee>();
//    }
//    public string Name { get; set; }

//    public List<Employee> Members { get; set; }

//    public decimal AllSalaries { get; set; }

//    public decimal AverageSalaries
//    {
//        get
//        {
//            return AllSalaries / Members.Count;
//        }
//    }

//    public void AddEmployee(string name, decimal salary)
//    {
//        Members.Add(new Employee(name, salary));
//        AllSalaries += salary;
//    }
//}

//class Employee
//{
//    public Employee(string name, decimal salary)
//    {
//        Name = name;
//        Salary = salary;
//    }
//    public string Name { get; set; }

//    public decimal Salary { get; set; }
//}

//class Program
//{
//    public static void Main()
//    {
//        List<Department> departments = new List<Department>();

//        int n = int.Parse(Console.ReadLine());


//        for (int i = 0; i < n; i++)
//        {

//            string[] employeeData = Console.ReadLine().Split();

//            string name = employeeData[0];
//            decimal salary = decimal.Parse(employeeData[1]);
//            string department = employeeData[2];

//            if (!departments.Any(x => x.Name == department))
//            {
//                departments.Add(new Department(department));
//            }

//            departments.First(x => x.Name == department).AddEmployee(name, salary);
//            //departments.First(x => x.Name == department).Members.Add(new Employee(name, salary));
//            //departments.First(x => x.Name == department).AllSalaries += salary;
//        }

//        Department bestDep = departments.OrderByDescending(x => x.AllSalaries / x.Members.Count).First();

//        Console.WriteLine("Highest Average Salary: " + bestDep.Name);

//        foreach (Employee employee in bestDep.Members.OrderByDescending(x => x.Salary))
//        {
//            Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
//        }
//    }
//}