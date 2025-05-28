using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets a list with all products.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/products
        /// </remarks>
        /// <response code="200">Returns "OK" with a list of all products</response>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return productService.GetAllProducts();
        }

        /// <summary>
        /// Gets a product by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/products/1
        /// </remarks>
        /// <response code="200">Returns "OK" with the product</response>
        /// <response code="404">Returns "Not Found" when product with the given
        /// id doesn't exist</response>
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = productService.GetById(id);

            if (product == null) return NotFound();

            return product;
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/products
        ///     {
        ///         "name": "Candy",
        ///         "description": "Chocolate"
        ///     }
        /// </remarks>
        /// <response code="201">Returns "Created" with the created product</response>
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            product = productService.CreateProduct(product.Name, product.Description);

            if (product == null) return NotFound();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        /// <summary>
        /// Edits a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/products/1
        ///     {
        ///         "id": 1,
        ///         "name": "New Candy",
        ///         "description": "Chocolate"
        ///     }
        /// </remarks>
        /// <response code="204">Returns "No Content"</response>
        /// <response code="400">Returns "Bad Request" when product with
        /// the given id doesn't exist</response>
        /// <response code="404">Returns "Not Found" when product with
        /// the given id doesn't exist</response>
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            if (productService.GetById(id) == null) return NotFound();

            productService.EditProduct(id, product);

            return NoContent();
        }

        /// <summary>
        /// Edits a product partially.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/products/1
        ///     {
        ///         "name": "Updated Name"
        ///     }
        /// 
        /// Only include the fields you want to update. Fields not provided will remain unchanged.
        /// </remarks>
        /// <response code="204">Returns "No Content"</response>
        /// <response code="400">Returns "Bad Request" when the ID in the body doesn't match the route</response>
        /// <response code="404">Returns "Not Found" when product with 
        /// the given id doesn't exist</response>
        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, Product product)
        {
            if (product.Id != 0 && product.Id != id)
            {
                return BadRequest("You cannot change the product ID.");
            }

            if (productService.GetById(id) == null) return NotFound();

            productService.EditProductPartially(id, product);

            return NoContent();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/products/1
        /// </remarks>
        /// <response code="200">Returns "OK" with the deleted product</response>
        /// <response code="404">Returns "Not Found" when product with 
        /// the given id doesn't exist</response>
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            if (productService.GetById(id) == null) return NotFound();

            var product = productService.DeleteProduct(id);

            return product;
        }
    }
}
