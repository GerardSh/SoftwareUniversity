namespace ConsoleApp
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student()
                {
                    FirstName = array[0],
                    LastName = array[1],
                    Grade = double.Parse(array[2])
                };

                students.Add(student);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}