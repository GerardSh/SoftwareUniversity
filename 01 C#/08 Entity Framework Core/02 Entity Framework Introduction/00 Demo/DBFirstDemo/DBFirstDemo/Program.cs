using DBFirstDemo.Infrastructure.Data;
using DBFirstDemo.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

class Program
{
    static async Task Main()
    {
        using SoftUniDbContext context = new SoftUniDbContext();

        var employees = await context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .ToListAsync();

        foreach (var employee in employees)
        {
            Console.WriteLine(employee.FirstName);
        }

        Console.WriteLine();

        var SQLCommand = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .Where(e => e.FirstName.StartsWith("a"))
            .ToQueryString();

        Console.WriteLine(SQLCommand);

        // Output:
        // SELECT[e].[FirstName], [e].[LastName], [e].[JobTitle], [e].[Salary]
        // FROM[Employees] AS[e]
        // WHERE[e].[FirstName] LIKE 'a%'
    }
}