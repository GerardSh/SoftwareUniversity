namespace ProductShop
{
    using ProductShop.Data;
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Models;
    using System.Xml.Serialization;
    using ProductShop.Dtos.Import;
    using ProductShop.DTOs.Export;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        static string result = string.Empty;

        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            // Console.WriteLine("Database migrated successfully!");

            // var inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            string result = GetUsersWithProducts(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            var usersDtos = (ICollection<ImportUserDto>)serializer.Deserialize(new StringReader(inputXml));

            if (usersDtos != null)
            {
                var users = usersDtos
                    .Where(IsValid)
                    .Select(u => new User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age
                    })
                    .ToList();

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
                    .Where(IsValid)
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
                    .Where(IsValid)
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
                    .Where(IsValid)
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

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersInfo = context.Users
                .Where(u => u.ProductsSold.Count > 0 
                         && u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold.Select(p => new ExportProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToList()
                })
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .Take(5)
                .ToList();

            var serializerXml = new XmlSerializer(typeof(List<ExportUserDto>),
                new XmlRootAttribute("Users"));
            var xmlResult = new StringWriter();
            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            serializerXml.Serialize(xmlResult, usersInfo, nameSpaces);

            return xmlResult.ToString().Trim();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto()
                {
                    Name = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var serializerXml = new XmlSerializer(typeof(List<ExportCategoryDto>),
                new XmlRootAttribute("Categories"));
            var xmlResult = new StringWriter();
            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            serializerXml.Serialize(xmlResult, categories, nameSpaces);

            return xmlResult.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new ExportUserProductDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductDto()
                    {
                        Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                            .Where(p => p.BuyerId.HasValue)
                            .Select(p => new ExportProductDto()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToList()
                    }
                })
                .ToList()
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToList();

            var finalResult = new ExportUserStartDto()
            {
                Count = context.Users.Count(x => x.ProductsSold.Count >= 1),
                Users = usersWithSoldProducts
            };

            var serializerXml = new XmlSerializer(typeof(ExportUserStartDto),
                new XmlRootAttribute("Users"));
            var xmlResult = new StringWriter();
            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");
            serializerXml.Serialize(xmlResult, finalResult, nameSpaces);

            return xmlResult.ToString().Trim();
        }

        //Helper method
        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults);

            return isValid;
        }
    }
}