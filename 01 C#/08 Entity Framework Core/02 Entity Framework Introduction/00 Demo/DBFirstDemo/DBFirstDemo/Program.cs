using DBFirstDemo.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;

class Program
{
    static void Main()
    {
        using SoftUniDbContext context = new SoftUniDbContext();

        var employees = context.Employees
            .Select(e => new 
            { 
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .ToList();

        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}