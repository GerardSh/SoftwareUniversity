using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
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
                .OrderBy(e=> e.FirstName)
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
    }
}