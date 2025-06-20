# In this folder, you will find solutions to some of the previous exams.
## Steps
1. Set the connection string in the appsettings.json
2. Create the entity classes. Avoid using magic numbers - constants should be defined in a separate static class to ensure code quality.
3. Create a Configuration folder within the Data project and move all entity configuration classes there. This will help organize the code better and keep the OnModelCreating() method in the DbContext clean and maintainable — which may also earn bonus points.
4. Add initial migration and then the seed migrations.
5. Password requirments.

```csharp
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
})
```

6. Scaffold the required Identity pages. Adjust the Login and Register pages by removing unnecessary sections according to the specified requirements, and implement the appropriate redirection logic within the methods of the Login page.
7. Copy the necessary entity properties into the appropriate ViewModel and adjust them to match the needs of the Razor view. Use a base ViewModel class to hold shared properties across multiple ViewModels, if applicable.
8. Add Services and their interfaces. Use entity-based services for simple or isolated logic, and use-case services when operations span across entities.
9. Register the services in the Program.cs - `builder.Services.AddScoped<IMyService, MyService>();`
## Select
In ASP.NET Core MVC, when posting a form that includes a dropdown (like Genres), the list of items (Model.Genres) is not automatically preserved after a POST. If model validation fails, you must manually reload the dropdown data in the [HttpPost] action before returning the view again — otherwise, the dropdown will be empty or broken.

When we have collections in the View Model of a particular type, we have to make a View Model for it and not use the Entity Model directly.

**ChatGPT**

This line:
```csharp
<select asp-for="@Model.TerrainId"  class="form-control" aria-required="true" asp-items="@(new SelectList(Model.Terrains, "Id", "Name"))">
```

does the following:

🔍 **Breakdown:**

-   `Model.Terrains`: a collection (e.g., `List<TerrainViewModel>` or `IEnumerable<Terrain>`)
    
-   Each item in that list must have at least two properties:
    
    -   `Id` (used for the `<option value="">`)
        
    -   `Name` (used for the display text inside the `<option>`)
        
🛠 **What `SelectList` does:**

`new SelectList(Model.Terrains, "Id", "Name")` creates a list of `<option>` elements like:

```csharp
<option value="1">Mountain</option>
<option value="2">Beach</option>
<option value="3">Desert</option>
```

⚙️ **How it binds:**

The `asp-for="@Model.TerrainId"` binds the selected `<option value="">` to the `TerrainId` property in your model when the form is posted.

As long as `Model.Terrains` contains objects with `Id` and `Name`, the select box is rendered properly with the correct value-text mapping.

✅ **In simple terms:**

1.  **You provide a collection** (`Model.Terrains`) with objects like `{ Id = 1, Name = "Mountain" }`, etc.
    
2.  The `<select>` tag helper:
    
    -   Creates `<option>` elements using `Id` as the `value` and `Name` as the visible text.
        
3.  When the form is **rendered**, the helper checks `Model.TerrainId` and **marks the corresponding `<option>` as selected** (if `TerrainId` matches any of the `Id`s).
    
4.  When the form is **submitted**, the selected option’s `value` is sent to the server, and **model binding** sets that value back into `TerrainId`.
## Date
`[RegularExpression(@"^\d{2}-\d{2}-\d{4}$", ErrorMessage = $"Date must be in {DestinationDateTimeFormat}.")]` - Usefull regex for dates validation.

Just to be safe, we can also manually validate the date before creating the Entity Model:

```csharp
if (!DateTime.TryParseExact(model.PublishedOn, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var publishedDate))
{
    throw new InvalidOperationException("Invalid date format");
}
```
## Authorization
We should always check if the user is logged in:

```csharp
string? userId = GetUserId();

if (string.IsNullOrEmpty(userId))
{
    return RedirectToAction("Login", "Account");
}
```

This check is important for ensuring that only authenticated users can submit forms. Without this check, anyone—whether logged in or not—could submit the form (even using tools like Postman or directly through a URL), potentially bypassing our authentication and authorization layers.

 POST actions: When we're processing forms or making state-changing requests (e.g., creating, updating, deleting data), it's critical to ensure the user is authenticated. The check ensures that unauthenticated users can't submit forms or perform actions that they shouldn't be able to.

## Misc
If soft delete is required, its better to use global filter in the OnModelCreating method in the DbContext class:

```csharp
builder.Entity<Destination>()
   .HasQueryFilter(d => !d.IsDeleted);
```

Its a good practise to make a BaseController class with common methods:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Horizons.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string? GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
```