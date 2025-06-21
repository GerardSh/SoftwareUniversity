using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.Web.Controllers
{
    public class BookController(IBookService bookService,
        IGenreService genreService)
        : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = GetUserId();

                var allRecipesModel = await
                     bookService.GetAllBooksAsync(userId);

                return View(allRecipesModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                string? userId = GetUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var model = new BookCreateInputModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(BookPublishedOnFormat),
                    Genres = await genreService.GetGenresDropdownAsync()
                };

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateInputModel model)
        {
            try
            {
                string userId = GetUserId()!;

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                if (!ModelState.IsValid)
                {
                    model.Genres = await genreService.GetGenresDropdownAsync();

                    return View(model);
                }

                bool addResult = await bookService.CreateBookAsync(userId, model);

                if (!addResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while creating the book.");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string? userId = GetUserId();

                BookDetailsViewModel? bookDetailsModel = await bookService
                    .GetBookDetailsAsync(id, userId);

                if (bookDetailsModel == null)
                {
                    if (User?.Identity?.IsAuthenticated == false)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Index");
                }

                return View(bookDetailsModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string userId = GetUserId()!;

                BookEditInputModel editInputModel = await bookService
                     .GetBookForEditingAsync(userId!, id);

                if (editInputModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                editInputModel.Genres = await genreService.GetGenresDropdownAsync();

                return View(editInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Genres = await genreService.GetGenresDropdownAsync();

                    return View(model);
                }

                string userId = GetUserId()!;
                string? publisherId = await bookService.GetPublisherIdAsync(model.Id);

                if (string.IsNullOrEmpty(publisherId) || publisherId.ToLower() != userId.ToLower())
                {
                    return RedirectToAction("Index");
                }

                bool editResult = await bookService.PersistUpdatedBookAsync(userId, model);

                if (!editResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while updating the book.");
                    return View(model);
                }

                return RedirectToAction(nameof(Details), new { model.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string userId = GetUserId()!;

                BookDeleteViewModel? deleteModel = await bookService
                    .GetBookForDeletingAsync(userId!, id);

                if (deleteModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(deleteModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(BookDeleteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Please do not modify the page!");
                    return View("Delete", model);
                }

                string userId = GetUserId()!;

                bool deleteResult = await bookService.SoftDeleteBookAsync(userId, model);

                if (!deleteResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while deleting the book.");
                    return View("Delete", model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyBooks()
        {
            try
            {
                string userId = GetUserId()!;

                IEnumerable<FavoriteBookViewModel>? favBooks = await
                     bookService.GetUserFavoriteBooksAsync(userId);

                return View(favBooks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyBooks(int? id, bool fromDetails = false)
        {
            try
            {
                string userId = GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                bool favAddResult = await bookService
                    .AddBookToUserFavoritesListAsync(userId, id.Value);

                if (fromDetails)
                {
                    return RedirectToAction("Details", new { id });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                string userId = GetUserId()!;

                bool removeFavorite = await bookService.RemoveBookFromUserFavoritesListAsync(userId, id);

                if (!removeFavorite)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(MyBooks));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
