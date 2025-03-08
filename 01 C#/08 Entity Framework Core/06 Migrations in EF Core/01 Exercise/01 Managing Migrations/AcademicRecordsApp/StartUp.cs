using AcademicRecordsApp.Data;
using AcademicRecordsApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AcademicRecordsApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using AcademicRecordsDbContext context = new AcademicRecordsDbContext();

            FillAllExamsWithDefaultCourse(context);

            Console.WriteLine("All exams have a course!");
        }

        private static void FillAllExamsWithDefaultCourse(AcademicRecordsDbContext dbContext)
        {
            Course testCourse = new Course()
            {
                Name = "Default Course"
            };

            dbContext.Courses.Add(testCourse);
            dbContext.SaveChanges();

            dbContext.Exams
                .Where(e => e.CourseId != null)
                .Update(e => new Exam()
                {
                    Course = testCourse
                });

            dbContext.SaveChanges();
        }
    }
}
