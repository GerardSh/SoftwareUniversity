using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Controllers
{
    public class ProductController : BaseController
    {
        ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();

            var model = await context.Products
                .Select(p => new ProductIndexViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    IsSeller = userId != null && p.SellerId == userId,
                    HasBought = userId != null && p.ProductsClients
                    .Any(pc => pc.ClientId == userId)
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new ProductAddViewModel();

            model.Categories = await context.Categories
                .Select(t => new CategoryViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await context.Categories
                    .Select(t => new CategoryViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();

                return View(model);
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            if (!DateTime.TryParseExact(model.AddedOn, ProductDateTimeFormat,
                null, System.Globalization.DateTimeStyles.None, out var addedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            Product product = new Product()
            {
                ProductName = model.ProductName,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                AddedOn = addedDate,
                CategoryId = model.CategoryId,
                SellerId = userId,
                Price = model.Price
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = await context.ProductsClients
                .Where(pc => pc.ClientId == userId)
                .Select(pc => new ProductCartViewModel()
                {
                    Id = pc.Product.Id,
                    ProductName = pc.Product.ProductName,
                    ImageUrl = pc.Product.ImageUrl,
                    Price = pc.Product.Price,
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            if (await context.ProductsClients.AnyAsync(pc => pc.ClientId == userId && pc.ProductId == id))
            {
                return RedirectToAction(nameof(Index));
            }

            var clientProduct = new ProductClient()
            {
                ClientId = userId,
                ProductId = id
            };

            await context.ProductsClients.AddAsync(clientProduct);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var clientProduct = await context.ProductsClients
                 .FirstOrDefaultAsync(pc => pc.ClientId == userId && pc.ProductId == id);

            if (clientProduct == null)
            {
                return RedirectToAction("Index");
            }

            context.ProductsClients.Remove(clientProduct);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = GetUserId();

            ProductDetailsViewModel? model = await context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    AddedOn = p.AddedOn.ToString(ProductDateTimeFormat),
                    CategoryName = p.Category.Name,
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == userId),
                    Seller = p.Seller.UserName,
                    ImageUrl = p.ImageUrl
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                if (User?.Identity?.IsAuthenticated == false)
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var categories = await context.Categories
                 .Select(t => new CategoryViewModel()
                 {
                     Id = t.Id,
                     Name = t.Name
                 })
                 .ToListAsync();

            var model = await context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductEditViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    Categories = categories,
                    CategoryId = p.CategoryId,
                    AddedOn = p.AddedOn.ToString(ProductDateTimeFormat)
                })
                .FirstOrDefaultAsync();

            if (model == null || model.SellerId != userId)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            string? userId = GetUserId();

            if (model == null || model.SellerId != userId)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await context.Categories
                    .Select(t => new CategoryViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();

                return View(model);
            }

            if (!DateTime.TryParseExact(model.AddedOn, ProductDateTimeFormat,
                null, System.Globalization.DateTimeStyles.None, out var addedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            Product? product = await context.Products.FindAsync(model.Id);

            if (product == null)
            {
                return View(model);
            }

            product.ProductName = model.ProductName;
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = addedDate;
            product.CategoryId = model.CategoryId;
            product.SellerId = userId;
            product.Price = model.Price;

            await context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = await context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDeleteViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Seller = p.Seller.UserName,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            if (model == null || model.SellerId != userId)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteViewModel model)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var product = await context.Products
                .FindAsync(model.Id);

            if (product == null || userId != product.SellerId)
            {
                return RedirectToAction("Index");
            }

            product.IsDeleted = true;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
