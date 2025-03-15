namespace ProductShop
{
    using ProductShop.Data;
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Models;
    using System.Xml.Serialization;
    using ProductShop.Dtos.Import;
    using ProductShop.DTOs.Export;

    public class StartUp
    {
        static string result = string.Empty;

        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            // Console.WriteLine("Database migrated successfully!");

            // var inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            string result = GetProductsInRange(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            var usersDtos = (ICollection<ImportUserDto>)serializer.Deserialize(new StringReader(inputXml));

            if (usersDtos != null)
            {
                var users = usersDtos
                    .Select(u => new User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age
                    }).ToList();

                context.Users.AddRange(users);
                context.SaveChanges();
                result = $"Successfully imported {users.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            var productsDtos = (ICollection<ImportProductDto>)serializer.Deserialize(new StringReader(inputXml));

            if (productsDtos != null)
            {
                var products = productsDtos
                    .Select(p => new Product()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        SellerId = p.SellerId,
                        BuyerId = p.BuyerId
                    })
                    .ToList();

                context.Products.AddRange(products);
                context.SaveChanges();

                result = $"Successfully imported {products.Count}";
            }

            return result;
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            var categoryDtos = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            if (categoryDtos != null)
            {
                var categories = categoryDtos
                    .Select(c => new Category
                    {
                        Name = c.Name
                    })
                    .Where(c => c.Name != null)
                    .ToList();

                context.Categories.AddRange(categories);
                context.SaveChanges();

                result = $"Successfully imported {categories.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            var categoryProductDtos = (ImportCategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            if (categoryProductDtos != null)
            {
                var categories = context.Categories
                    .Select(c => c.Id)
                    .ToList();

                var products = context.Products
                    .Select(p => p.Id)
                    .ToList();

                var categoryProducts = categoryProductDtos
                    .Select(x => new CategoryProduct
                    {
                        CategoryId = x.CategoryId,
                        ProductId = x.ProductId
                    })
                    .Where(cp => categories.Contains(cp.CategoryId) &&
                                   products.Contains(cp.ProductId))
                    .ToList();

                context.CategoryProducts.AddRange(categoryProducts);
                context.SaveChanges();

                result = $"Successfully imported {categoryProducts.Count}";
            }

            return result;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInfo = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = string.Join(" ", p.Buyer.FirstName, p.Buyer.LastName)
                })
                .OrderBy(s => s.Price)
                .Take(10)
                .ToList();

            var serializerXml = new XmlSerializer(typeof(List<ExportProductDto>),
                new XmlRootAttribute("Products"));
            var xmlResult = new StringWriter();
            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            serializerXml.Serialize(xmlResult, productsInfo, nameSpaces);

            return xmlResult.ToString().Trim();
        }
    }
}