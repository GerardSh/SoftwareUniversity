namespace JsonDemo
{
    using System;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Student student = new Student()
            {
                Id = 1,
                Name = "Пешо",
                Number = "F1234567890",
                YearOfStudy = 1
            };

            Console.WriteLine("*******************************");
            Console.WriteLine("     System.Text.Json Demo");
            Console.WriteLine("*******************************");
            Console.WriteLine();

            SystemJson.SystemJsonDemo(student);

            Console.WriteLine();
            Console.WriteLine("*******************************");
            Console.WriteLine("         JSON.NET Demo");
            Console.WriteLine("*******************************");
            Console.WriteLine();

            JsonNet.JsonNetDemo(student);
        }
    }
}
