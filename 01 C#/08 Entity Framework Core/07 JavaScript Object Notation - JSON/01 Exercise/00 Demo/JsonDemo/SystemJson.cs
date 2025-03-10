namespace JsonDemo
{
    using System.Text.Json;

    public static class SystemJson
    {
        public static void SystemJsonDemo(Student student)
        {
            string serializedStudent = JsonSerializer.Serialize(student);
            string serializedStudentWithExtensionMethod = student.ToJson();

            Console.WriteLine("Serialized student (default settings, without custom configuration):");
            Console.WriteLine(serializedStudent);
            Console.WriteLine();

            Console.WriteLine("Serialized student (using extension method with custom configuration):");
            Console.WriteLine(serializedStudentWithExtensionMethod);

            Console.WriteLine("----------------------");

            Student? newStudent = JsonSerializer.Deserialize<Student>(serializedStudent);
            Student? newStudentWithExtensionMethod = serializedStudent.FromJson<Student>();

            if (newStudent != null && newStudentWithExtensionMethod != null)
            {
                Console.WriteLine("Deserialized student (using default deserialization):");
                Console.WriteLine($"Name: {newStudent.Name}, FakNumber: {newStudent.Number}");
                Console.WriteLine();

                Console.WriteLine("Deserialized student (using extension method for deserialization):");
                Console.WriteLine($"Name: {newStudentWithExtensionMethod.Name}, FakNumber: {newStudentWithExtensionMethod.Number}");

                Console.WriteLine("----------------------");
            }

            File.WriteAllText(@"..\..\..\student.json", serializedStudent);

            string jsonString = File.ReadAllText(@"..\..\..\student.json");

            Student? newStudentFromFileString = JsonSerializer.Deserialize<Student>(jsonString);

            if (newStudentFromFileString != null)
            {
                Console.WriteLine("Deserialized student from JSON file:");
                Console.WriteLine($"Name: {newStudentFromFileString.Name}, FakNumber: {newStudentFromFileString.Number}");
            }
        }
    }
}
