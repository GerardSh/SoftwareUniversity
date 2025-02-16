using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            var context = new SoftUniContext();

            // Console.WriteLine(GetEmployeesFullInformation(context));

            // Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            // Console.WriteLine(AddNewAddressToEmployee(context));

            // Console.WriteLine(GetEmployeesInPeriod(context));

            // Console.WriteLine(GetEmployeesInPeriod2(context));

            // Console.WriteLine(GetAddressesByTown(context));

            // Console.WriteLine(GetEmployee147(context));

            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
               .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
               .ToList();

            sb.Clear();

            foreach (var employee in employees)
            {
                sb.AppendLine(employee);
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToList();

            sb.Clear();

            foreach (var em in employees)
            {
                sb.AppendLine($"{em.FirstName} - {em.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToList();

            sb.Clear();

            foreach (var em in employees)
            {
                sb.AppendLine($"{em.FirstName} {em.LastName} from {em.DepartmentName} - ${em.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            var employees = context.Employees
                .Include(e => e.Address)
                .ToList();

            Employee employee = employees.FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = newAddress;

            context.SaveChanges();

            sb.Clear();

            foreach (var em in employees.OrderByDescending(em => em.AddressId).Take(10))
            {
                sb.AppendLine($"{em.Address.AddressText}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Include(e => e.Manager)
                .Take(10)
                .ToList();

            sb.Clear();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    if (project.Project.StartDate.Year < 2001 || project.Project.StartDate.Year > 2003)
                    {
                        continue;
                    }

                    string startDate = project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    string endDate = project.Project.EndDate != null
                                     ? project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                     : "not finished";

                    sb.AppendLine($"--{project.Project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}