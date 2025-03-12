namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            // Console.WriteLine("Database migrated successfully!");

            string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");
            string result = GetSoldProducts(dbContext);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDTO[]? userDtos = JsonConvert
                .DeserializeObject<ImportUserDTO[]>(inputJson);

            if (userDtos != null)
            {
                ICollection<User> usersToAdd = new List<User>();

                foreach (var userDto in userDtos)
                {
                    if (!IsValid(userDto)) continue;

                    int? userAge = null;

                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);

                        if (!isAgeValid) continue;

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };

                    usersToAdd.Add(user);
                }

                context.Users.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportProductDto[]? productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);

            if (productDtos != null)
            {
                ICollection<Product> validProducts = new List<Product>();
                //ICollection<int> dbUsers = context.Users
                //    .Select(u => u.Id)
                //    .ToArray();

                foreach (var productDto in productDtos)
                {
                    if (!IsValid(productDto)) continue;

                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal productPrice);
                    bool isSellerValid = int.TryParse(productDto.SellerId, out int sellerId);

                    if (!isPriceValid || !isSellerValid) continue;

                    int? buyerId = null;

                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerIdValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);

                        if (!isBuyerIdValid) continue;

                        buyerId = parsedBuyerId;

                        //   if (!dbUsers.Contains((int)buyerId)) continue;
                    }

                    // if (!dbUsers.Contains(sellerId)) continue;

                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = productPrice,
                        SellerId = sellerId,
                        BuyerId = buyerId,
                    };

                    validProducts.Add(product);
                }

                context.Products.AddRange(validProducts);
                context.SaveChanges();

                result = $"Successfully imported {validProducts.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryDto[]? categoryDtos = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new List<Category>();

            if (categoryDtos != null)
            {

                foreach (var categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto)) continue;

                    Category category = new Category()
                    {
                        Name = categoryDto.Name
                    };

                    validCategories.Add(category);
                }

                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryProductDto[]? catProdDtos = JsonConvert
                .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            if (catProdDtos != null)
            {
                ICollection<CategoryProduct> validCatProd = new List<CategoryProduct>();

                foreach (var catProdDto in catProdDtos)
                {
                    if (!IsValid(catProdDto)) continue;

                    bool isProductIdValid = int.TryParse(catProdDto.ProductId, out int prodId);
                    bool isCategoryIdValid = int.TryParse(catProdDto.CategoryId, out int catId);

                    if (!isProductIdValid || !isCategoryIdValid) continue;

                    var catProd = new CategoryProduct()
                    {
                        ProductId = prodId,
                        CategoryId = catId
                    };

                    validCatProd.Add(catProd);
                }

                context.CategoriesProducts.AddRange(validCatProd);
                context.SaveChanges();

                result = $"Successfully imported {validCatProd.Count}"; ;
            }

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 &&
                           p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToArray();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(products, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver,
                    Formatting = Formatting.Indented
                });

            return jsonResult;
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