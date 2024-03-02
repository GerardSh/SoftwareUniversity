class Student
{
    public Student(string firstName, string lastName, int age, string homeTown)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.HomeTown = homeTown;
    }
    public override string ToString()
    {
        return $"{FirstName} {LastName} is {Age} years old.";
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }

    static void Main()
    {
        List<Student> students = new List<Student>();
        string input;

        while ((input = Console.ReadLine()) != "end")
        {
            string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName = commands[0];
            string lastName = commands[1];
            int age = int.Parse(commands[2]);
            string homeTown = commands[3];

            Student student = new Student(firstName, lastName, age, homeTown);

            students.Add(student);
        }
        string cityToFilter = Console.ReadLine();

        List<Student> filteredStudents = students.Where(x => x.HomeTown == cityToFilter).ToList();

        foreach (Student student in filteredStudents)
        {
            Console.WriteLine(student);
        }

        Student[] studentsTest = students.ToArray();

        Console.WriteLine(studentsTest[0]);
    }
}