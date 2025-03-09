namespace JsonDemo
{
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "Пешо",
                Number = "F1234567890",
                YearOfStudy = 1
            };

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string serializedStudent = JsonSerializer.Serialize(student);
            string serializedStudentWithExtensionMethod = student.ToJson();

            Console.WriteLine(serializedStudent);
            Console.WriteLine(serializedStudentWithExtensionMethod);

            Student? newStudent = JsonSerializer.Deserialize<Student>(serializedStudent);
            Student? newStudentWithExtensionMethod = serializedStudent.FromJson<Student>();

            if (newStudent != null && newStudentWithExtensionMethod != null)
            {
                Console.WriteLine("Student from string:");
                Console.WriteLine($"Name: {newStudent.Name}, FakNumber: {newStudent.Number}");
                Console.WriteLine($"Name: {newStudentWithExtensionMethod.Name}, FakNumber: {newStudentWithExtensionMethod.Number}");
            }

            File.WriteAllText(@"..\..\..\student.json", serializedStudent);

            string jsonString = File.ReadAllText(@"..\..\..\student.json");

            Student? newStudentFromFileString = JsonSerializer.Deserialize<Student>(jsonString);

            if (newStudentFromFileString != null)
            {
                Console.WriteLine("Student from JSON file:");
                Console.WriteLine($"Name: {newStudentFromFileString.Name}, FakNumber: {newStudentFromFileString.Number}");
            }
        }
    }
}
