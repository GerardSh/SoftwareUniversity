using ProductsApi.Data;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext data;

        public ProductService(ProductDbContext data)
        {
            this.data = data;
        }

        public List<Product> GetAllProducts()
        {
            return data.Products.ToList();
        }

        public Product GetById(int id)
        {
            return data.Products.Find(id);
        }

        public Product CreateProduct(string name, string description)
        {
           var product = new Product()
           {
               Name = name,
               Description = description
           };

            data.Products.Add(product);
            data.SaveChanges();

            return product;
        }

        public void EditProduct(int id, Product product)
        {
            var dbProduct = data.Products.Find(id);

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;

            data.SaveChanges();
        }

        public void EditProductPartially(int id, Product product)
        {
            var dbProduct = data.Products.Find(id);

            dbProduct.Name = String.IsNullOrEmpty(product.Name)
                ? dbProduct.Name : product.Name;

            dbProduct.Description = String.IsNullOrEmpty(product.Description)
                ? dbProduct.Description : product.Description;

            data.SaveChanges();
        }

        public Product DeleteProduct(int id)
        {
            var product = data.Products.Find(id);

            data.Products.Remove(product);
            data.SaveChanges();

            return product;
        }
    }
}
