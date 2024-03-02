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

            for (int i = 0; i < students.Count; i++)
            {
                if (student.FirstName == students[i].FirstName && student.LastName == students[i].LastName)
                {
                    students.RemoveAt(i);
                }
            }

            students.Add(student);
        }
        string cityToFilter = Console.ReadLine();

        List<Student> filteredStudents = students.Where(x => x.HomeTown == cityToFilter).ToList();

        foreach (Student student in filteredStudents)
        {
            Console.WriteLine(student);
        }
    }
}

////2
//class Student
//{
//    public Student(string firstName, string lastName, int age, string homeTown)
//    {
//        this.FirstName = firstName;
//        this.LastName = lastName;
//        this.Age = age;
//        this.HomeTown = homeTown;
//    }
//    public override string ToString()
//    {
//        return $"{FirstName} {LastName} is {Age} years old.";
//    }

//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public int Age { get; set; }
//    public string HomeTown { get; set; }

//    static void Main()
//    {
//        List<Student> students = new List<Student>();
//        string input;

//        while ((input = Console.ReadLine()) != "end")
//        {
//            string[] studentInformation = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

//            string firstName = studentInformation[0];
//            string lastName = studentInformation[1];
//            int age = int.Parse(studentInformation[2]);
//            string homeTown = studentInformation[3];

//            if (IsStudentExisting(students, firstName, lastName))
//            {
//                Student student = GetStudent(students, firstName, lastName);
//                student.FirstName = firstName;
//                student.LastName = lastName;
//                student.Age = age;
//                student.HomeTown = homeTown;
//            }
//            else
//            {
//                Student student = new Student(firstName, lastName, age, homeTown);
//                students.Add(student);
//            }
//        }
//        string cityToFilter = Console.ReadLine();

//        List<Student> filteredStudents = students.Where(x => x.HomeTown == cityToFilter).ToList();

//        foreach (Student student in filteredStudents)
//        {
//            Console.WriteLine(student);
//        }
//    }

//    private static Student GetStudent(List<Student> students, string firstName, string lastName)
//    {
//        Student existingStudent = null;

//        foreach (Student student in students)
//        {
//            if (student.FirstName == firstName && student.LastName == lastName)
//            {
//                existingStudent = student;
//            }
//        }

//        return existingStudent;
//    }

//    private static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
//    {
//        foreach (Student student in students)
//        {
//            if (student.FirstName == firstName && student.LastName == lastName)
//            {
//                return true;
//            }
//        }

//        return false;
//    }
//}

////3
//class Student
//{
//    public Student()
//    {

//    }
//    public Student(string firstName, string lastName, int age, string homeTown)
//    {
//        this.FirstName = firstName;
//        this.LastName = lastName;
//        this.Age = age;
//        this.HomeTown = homeTown;
//    }
//    public override string ToString()
//    {
//        return $"{FirstName} {LastName} is {Age} years old.";
//    }

//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public int Age { get; set; }
//    public string HomeTown { get; set; }

//    static void Main()
//    {
//        List<Student> students = new List<Student>();
//        string input;

//        while ((input = Console.ReadLine()) != "end")
//        {
//            string[] studentInformation = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

//            string firstName = studentInformation[0];
//            string lastName = studentInformation[1];
//            int age = int.Parse(studentInformation[2]);
//            string homeTown = studentInformation[3];

//            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

//            List<string> test = new List<string>();

//            if (student == null)
//            {
//                students.Add(new Student()
//                {
//                    FirstName = firstName,
//                    LastName = lastName,
//                    Age = age,
//                    HomeTown = homeTown
//                });

//            }
//            else
//            {
//                student.Age = age;
//                student.HomeTown = homeTown;
//                student.FirstName = firstName;
//                student.LastName = lastName;
//            }
//        }

//        string cityToFilter = Console.ReadLine();

//        List<Student> filteredStudents = students.Where(x => x.HomeTown == cityToFilter).ToList();

//        foreach (Student student in filteredStudents)
//        {
//            Console.WriteLine(student);
//        }
//    }
//}