namespace JsonDemo
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using System.Text.Json.Nodes;
    using System.Xml;

    public static class JsonNet
    {
        public static void JsonNetDemo(Student student)
        {
            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = defaultContractResolver,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            string serializedStudent = JsonConvert.SerializeObject(student);

            Console.WriteLine("Serialized student (default settings, without custom configuration):");
            Console.WriteLine(serializedStudent);
            Console.WriteLine();

            string serilizedStudentWithConfiguration = JsonConvert.SerializeObject(student, settings);

            Console.WriteLine("Serialized student (with custom configuration):");
            Console.WriteLine(serilizedStudentWithConfiguration);
            Console.WriteLine();

            JObject studentObject = JObject.Parse(serializedStudent);

            Student? newStudent = JsonConvert.DeserializeObject<Student>(serializedStudent);

            if (newStudent != null)
            {
                Console.WriteLine("Deserialized student (using default deserialization):");
                Console.WriteLine($"Name: {newStudent.Name}, FakNumber: {newStudent.Number}");
                Console.WriteLine();
            }

            var template = new
            {
                Name = string.Empty,
                Number = string.Empty
            };

            var studentAnonymousType = JsonConvert.DeserializeAnonymousType(serializedStudent, template);

            if (studentAnonymousType != null)
            {
                Console.WriteLine("Deserialized anonymous type student:");
                Console.WriteLine($"Name: {studentAnonymousType.Name}, FakNumber: {studentAnonymousType.Number}");
                Console.WriteLine();
            }

            Console.WriteLine("JObjects can be queried with LINQ:");
            var json = JObject.Parse(@"{'products': [
            {'name': 'Fruits', 'products': ['apple', 'banana']},
            {'name': 'Vegetables', 'products': ['cucumber']}]}"
            );

            var products = json["products"]
                .Select(t =>
                    string.Format("{0} ({1})",
                        t["name"],
                        string.Join(", ", t["products"].Select(p => p.ToString()))
                    )
                ).ToList();

            // Output the result
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("XML-to-JSON:");

            string xml = @"<?xml version=""1.0"" standalone=""no""?>
             <root>
                <person id=""1"">
                    <name>Alan</name>
                    <url>www.google.com</url>
                </person>
                <person id=""2"">
                    <name>Louis</name>
                    <url>www.yahoo.com</url>
                </person>
            </root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(jsonText);
        }
    }
}
