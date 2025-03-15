namespace ProductShop
{
    using ProductShop.Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Data;
    //using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json.Serialization;
    using System.Xml.Serialization;
    using ProductShop.Dtos.Import;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            // Console.WriteLine("Database migrated successfully!");

            var inputXml = File.ReadAllText("../../../Datasets/users.xml");

            string result = ImportUsers(dbContext, inputXml);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("Users"));
            var deserialUsers = (ICollection<UserImportDto>)serializer.Deserialize(new StringReader(inputXml));

            var users = deserialUsers
                .Select(u => new User()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                }).ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}