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

           Console.WriteLine(GetEmployeesFullInformation(context));
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
    }
}