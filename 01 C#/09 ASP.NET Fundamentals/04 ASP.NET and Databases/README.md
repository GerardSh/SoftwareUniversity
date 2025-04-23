# General
## Entity Framework Core
Entity Framework Core е стандартната ORM рамка за .NET.

Предоставя заявки към данни и CRUD операции на базата на LINQ.

Автоматично проследява промените в обекти в паметта.

Работи с много релационни бази данни (чрез различни доставчици).

С отворен код и независимо издание на версиите.
### Code First Approach
Code First означава да напишем .NET класовете и да оставим EF Core да създаде базата данни на база зададените съответствия.

Позволява писане на код без необходимост от дефиниране на съответствия в XML или ръчно създаване на таблици в базата данни.

Обектите се дефинират във формат на C# класове.

Осигурява запазване на данни в база без допълнителна конфигурация.

Промени в кода могат да се отразяват в схемата чрез миграции.

Data Annotations или Fluent API описват пропъртитата на обектите.

Атрибути като `Key`, `Required`, `MaxLength` и други определят правилата и ограниченията.
#### Basic Workflow
Дефинираме модела на данни (чрез Code First или чрез Scaffold от съществуваща база данни).

Пишем и изпълняваме заявка върху `IQueryable` колекция.

EF Core генерира и изпълнява SQL заявка директно в базата данни.

EF преобразува резултатите от заявката в .NET обекти.

Модифицираме данните чрез C# код и извикваме `SaveChanges()`.

Entity Framework генерира и изпълнява SQL команда, за да промени базата данни.
### Components
#### Domain Classes (Models)
Група от обикновени C# класове (POCO).

Могат да съдържат навигационни пропъртита за връзки между таблици.

Препоръчително е да се намират в отделна библиотека от класове.

```csharp
public class ProductNote
{
    public int Id { get; set; }                   // Primary key  
    public string Content { get; set; }  
    public int ProductId { get; set; }            // Foreign key  
    public Product Product { get; set; }          // Navigation property  
}
```

Още един пример за домейн клас:

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();  // Navigation property (one-to-many)
}
```

Този клас дефинира едно към много връзка – един продукт може да има множество бележки (`ProductNote`).
#### The DbContext Class
Обикновено се именува по името на базата данни, например `ShoppingListDbContext`.

```csharp
public class ShoppingListDbContext : DbContext
{
    // Inherits the DbContext class
}
```

Управлява домейн класовете чрез тип `DbSet<T>`.

Позволява лесна навигация между таблици с връзки.

Отговаря за създаване, изтриване и мигриране на базата данни.

Изпълнява LINQ заявки като native SQL заявки.

Свойства на `DbContext`:
- `Database` – предоставя методи като `EnsureCreated()` и `EnsureDeleted()`, както и достъп до DB връзката
- `ChangeTracker` – съдържа информация за автоматичното проследяване на промени
##### Defining DbContext Class
```csharp
// EF Reference
using Microsoft.EntityFrameworkCore; 

public class ShoppingListDbContext : DbContext
{
    // Accepts options through the constructor
    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();  // Ensures the creation of the database
    }

    // Collections of entities
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductNote> ProductNotes { get; set; }

    // Use the Fluent API to describe our table relations to EF Core
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasMany(p => p.ProductNotes)  // One product can have many product notes
            .WithOne(r => r.Product);      // Every product note has one product
    }
}
```
### Configuration - NuGet Packages, Configuration
#### EF Core Setup
За да добавим EF Core поддръжка към проекта, можем да използваме следната команда в **Package Manager Console**:

```
Install-Package Microsoft.EntityFrameworkCore  
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

Можем също да използваме .NET Core CLI за добавяне на EF Core:

```
dotnet add package Microsoft.EntityFrameworkCore
```

EF Core е модулен, така че трябва да инсталираме съответните доставчици на данни (например за SQL Server - `Microsoft.EntityFrameworkCore.SqlServer`).

Ако искаме да използваме Entity Framework Core CLI инструменти, трябва да инсталираме и следните пакети:

```
Install-Package Microsoft.EntityFrameworkCore.Design  
dotnet add package Microsoft.EntityFrameworkCore.Design  
```

Тези стъпки ще осигурят нужните зависимости за работа с EF Core и ще позволят използването на различни функционалности, като миграции и CLI инструменти.
#### How to Connect to SQL Server
В ASP.NET Core връзката към SQL Server се конфигурира чрез **`appsettings.json`** файл. Тя се задава под секцията `"ConnectionStrings"` и изглежда по следния начин:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ShoppingList;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

В ASP.NET Core използваме класа `Program`, за да конфигурираме зависимостите и да кажем на `DbContext` да използва SQL Server с нашия connection string от `appsettings.json`.

Примерният код изглежда така:

```csharp
var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder
    .Services
    .AddDbContext<ShoppingListDbContext>(
        x => x.UseSqlServer(connectionString));
```

Този код:

- Чете връзката към базата данни от конфигурационния файл (`appsettings.json`).
- Регистрира `ShoppingListDbContext` в DI контейнера.
- Указва на EF Core да използва SQL Server като доставчик на база данни.

Това е стандартният начин за конфигуриране на `DbContext` в модерните ASP.NET Core приложения.
#### `Database.EnsureCreated()`
Когато създаваме `DbContext`, можем да извикаме `Database.EnsureCreated()`. Това прави следното:

- Ако базата данни **не съществува**, методът ще я **създаде**, заедно със **схемата**.
- **Не използва миграции** – затова **при промяна на схемата** трябва **да изтрием цялата база** и да я създадем отново.
- Подходящ е основно за **бързо прототипиране** или **учебни проекти**, но **не се препоръчва за production**.

**Логика:**

1. **Базата съществува?**  

    – Да → **Използва се**  
    – Не → **Създава се база и схема**

Ако искаме пълна миграционна поддръжка и контрол върху версиите на базата, по-добре е да ползваме `Database.Migrate()` вместо `EnsureCreated()`.

```csharp
public class ShoppingListDbContext : DbContext
{
    public ShoppingListDbContext(
        DbContextOptions<ShoppingListDbContext> options)
        : base(options)
        => Database.EnsureCreated(); 
		// This will create the DB schema if the DB does not exist
		// Any change in the data entities will not change the DB
		// You should update the DB by hand or drop and re-create the DB after each entity change!
}
```
# Misc
# ChatGPT
## Primary Constructor
**🔹 What is a _Primary Constructor_ in C#?**

Introduced in **C# 12**, _primary constructors_ allow you to define constructor parameters **directly on the class declaration**, without writing a separate constructor or defining `private readonly` fields.

**📦 Example without primary constructor:**

```csharp
public class MyController : Controller
{
    private readonly IMyService _myService;

    public MyController(IMyService myService)
    {
        _myService = myService;
    }
}
```

**📦 Example with primary constructor:**

```csharp
public class MyController(IMyService myService) : Controller
{
    public IActionResult Index()
    {
        return View(); // you can use myService directly
    }
}
```

**✅ Benefits for Dependency Injection**

- Cleaner and shorter code
- No need to declare a `private readonly` field
- Dependency injection becomes more concise
- Great fit for DI style — "tell me what you need, and I’ll give it to you"

**⚠️ Limitations - You can't use another constructor**

**You can't have multiple constructors** if you use a primary constructor. This reduces flexibility in scenarios like:

- Needing a parameterless constructor for unit testing
- Supporting multiple initialization paths

**🧠 Example in ASP.NET Core Controller:**

```csharp
public class ProductsController(IProductService productService) : Controller
{
    public IActionResult List()
    {
        var items = productService.GetAll();
        return View(items);
    }
}
```

This works perfectly with ASP.NET Core’s built-in DI container — it will automatically inject `IProductService` as long as it’s registered in the container.

**📌 When to Use Primary Constructors?**

**Use them when:**

- Your class has a single initialization path
- You don’t need extra logic in the constructor
- You want minimal, clean code
- You're writing ASP.NET controllers, DTOs, records, etc.

**Avoid them when:**

- You need more than one constructor
- You need custom logic during object creation
- You're dealing with serialization that requires a parameterless constructor
## How `model` and `ModelState` reach the Razor view in ASP.NET MVC
When you submit a form and validation fails, you typically return the view like this:

```csharp
return View(model);
```

**🔄 What really happens under the hood:**

The line above is **roughly equivalent** to this:

```csharp
ViewData.Model = model;
ViewData.ModelState = this.ModelState;
return new ViewResult { ViewData = this.ViewData };
```

So even though you don’t explicitly pass `ModelState`, it’s carried over via `ViewData`.

**📥 In the Razor view:**

Helpers like these:

```
<input asp-for="Email" />
<span asp-validation-for="Email"></span>
```

will:

- Use `Model.Email` from `ViewData.Model` to set the input value.

- Check `ModelState["Email"].Errors` (from `ViewData.ModelState`) to highlight invalid fields and show error messages.

**🧼 Lifecycle**

- `Model` and `ModelState` only live during **the current request**.
    
- After the controller returns the view and the response is sent, both are **discarded**.
    
- Every new request gets a fresh `ModelState`.

**✅ When to return the view**

```csharp
if (!ModelState.IsValid)
{
    return View(model); // this preserves both the model and validation errors
}
```

This ensures that:

- The user sees their original inputs
    
- Validation errors are shown automatically
### What Happens When Validation Fails on POST in ASP.NET MVC
**You said:**

Okay, help me understand how the view is rebuilt on POST when validation fails. The `[HttpPost]` action is returning the Razor view, and the tag helper `asp-validation-for` checks each field to see if the corresponding property failed validation. If it did, ASP.NET adds a CSS class and also inserts content into the `<span>` tag. This is the main difference between GET and POST, right?

**ChatGPT said:**

Exactly, Gerard — you're thinking about this in a very precise and correct way. Let's break it down step by step so it clicks 100%.

**🧠 What Happens When Validation Fails on POST in ASP.NET MVC**

**📤 Step 1: You submit the form (POST)**

- The browser sends the form values to the `[HttpPost]` action.
- ASP.NET **model binding** takes over — it tries to bind the form values to your `ProductViewModel`.

**⚖️ Step 2: ASP.NET performs validation**

- Validation attributes like `[Required]`, `[MaxLength]`, etc., are checked.
- If any field fails validation, **`ModelState.IsValid == false`**.

**🔁 Step 3: You return the same view with the model:**

```csharp
if (!ModelState.IsValid)
{
    return View(model); // 🔁 Return the same view, but with validation errors
}
```

ASP.NET does **not** do a redirect — it returns the same `.cshtml` file for rendering.

**🛠️ How the Razor View Is Built Again**

Now that you're in the view again (same as on GET, but with a difference), here's the trick:

**✅ On GET:**

- `ModelState` is empty — no validation attempted.
- Tag helpers like `asp-validation-for` render empty spans.

**❌ On POST (with validation errors):**

- `ModelState` now contains errors.
- Razor helpers like `asp-validation-for="Name"` **look up the `ModelState` errors** for the `"Name"` key.
- If there's an error, it renders:

```html
<span class="field-validation-error text-danger">Name is required.</span>
```

And for the input:

```html
<input class="form-control input-validation-error" />
```

✅ ASP.NET **adds a CSS class** like `input-validation-error`  
✅ ASP.NET **injects the error message** in the `<span>`

**🧩 So the difference between GET and POST:**

|                      | GET                         | POST (Validation Fails)              |
| -------------------- | --------------------------- | ------------------------------------ |
| `ModelState`         | Empty                       | Contains validation errors           |
| `asp-for`            | Just binds the model values | Binds + flags input with error class |
| `asp-validation-for` | Renders empty `<span>`      | Fills `<span>` with error text       |
| Input box            | Regular style               | Gets red border or error class       |

**🔍 How it all works internally:**

When you do `return View(model);`, behind the scenes this is roughly what happens:

```csharp
ViewData.Model = model;
ViewData.ModelState = this.ModelState;
return new ViewResult { ViewData = this.ViewData };
```

So both the **model** and the **ModelState** are passed to the Razor view.

Then the tag helpers (`asp-for`, `asp-validation-for`) read from `ViewData.ModelState` and act accordingly.

**You said:**

The tag helpers (`asp-for`, `asp-validation-for`) read from `ViewData.ModelState` and act accordingly. They also read during the HTTP GET, but since the model state is still valid at that point, it's empty—right?

**ChatGPT said:**

Exactly, Gerard — you nailed it! 💡

**✅ During the HTTP GET:**

- The user just visits the page, no form submitted yet.
- `ModelState` is **empty** or implicitly valid.
- Tag helpers like `asp-validation-for="Name"` look into `ViewData.ModelState`, find nothing wrong, so they render:

```html
<span class="text-danger"></span> <!-- Just an empty span -->
```

And the input:

```html
<input class="form-control" />
```

No validation classes, no error messages.

**❌ During the HTTP POST (when validation fails):**

- Validation happens after the user clicks submit - ASP.NET tries to bind the model and validate it.
- `ModelState` is **populated with errors** (e.g. “Name is required”).
- Now `asp-validation-for="Name"` finds an error in `ViewData.ModelState["Name"]`, so it renders:

```html
<span class="field-validation-error text-danger">Name is required.</span>
```

And the input:

```html
<input class="form-control input-validation-error" />
```

So yup — the tag helpers always _read_ from `ViewData.ModelState`, but on GET there's nothing in there yet. It’s like a mailbox: on GET it’s empty, on POST it might have "error letters" in it. 📬
## HTML Form Default Behavior
- **No `action` specified** →  

    The form submits to the **same URL** as the current page.

- **No `method` specified** →  

    Defaults to **`GET`** (form data is sent in the URL as query parameters).

- **If `method="POST"` is used without `action`** →  

    The form sends a **POST** request to the current page's URL, with data in the body.

This behavior makes it easy to build forms that submit back to the same page for processing, especially in Razor views with `[HttpGet]` and `[HttpPost]` methods using the same URL.
## `asp-for` Helper Tag
1. **[`HttpGet`] — Sending data to the view (Pre-filling form)**

When the controller returns a view with a model:

```csharp
public IActionResult Edit(int id)
{
    var model = new ProductViewModel { Name = "Test Product" };
    return View(model);
}
```

 In the Razor view:

```html
<input asp-for="Name" class="form-control" />
```

The `asp-for` tag helper generates:

```html
<input type="text" name="Name" value="Test Product" class="form-control" />
```

So the field is **pre-filled with the model's value**.

2. **[`HttpPost`] — Receiving data from the view (Form submission)**

When the user submits the form:

```html
<form method="post">
    <input asp-for="Name" />
    <input type="submit" value="Save" />
</form>
```

ASP.NET Core automatically matches form fields (`name="Name"`) to the view model’s properties:

```csharp
[HttpPost]
public IActionResult Edit(ProductViewModel model)
{
    // model.Name will contain the submitted value
}
```

This process is called **model binding** — it works based on matching the `name` attributes in the form with the property names in your view model.

**🧠 Summary Key Points**

- `asp-for` connects form fields to model properties in both directions.
- On **GET**: it populates form fields with model data.
- On **POST**: it helps ASP.NET bind form data back into the model.
- All of this is part of ASP.NET’s **Model-View-Controller (MVC)** pattern, making data handling clean and consistent.
## Model Binding with Different Models and Same Properties
If **the property names in the Razor model (`@model`) and in the `[HttpPost]` method match**, everything will work perfectly – **even if the classes are different**, as long as the properties have the same names and compatible types.

**📌 Example:**

View:

```csharp
@model ProductViewModel
<form method="post">
    <input asp-for="Name" />
    <input asp-for="Price" />
    <button type="submit">Submit</button>
</form>
```

`ProductViewModel:`

```csharp
public class ProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

Controller (POST method):

```csharp
[HttpPost]
public IActionResult Add(ProductFormModel model)
{
    // model.Name and model.Price will be filled
}
```

`ProductFormModel:`

```csharp
public class ProductFormModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

🔸 Even though `ProductViewModel` and `ProductFormModel` are different classes, **Model Binding will work**, because the input elements in the form have `name="Name"` and `name="Price"`, and `ProductFormModel` expects those exact fields.

**🧠 Summary:**

- `asp-for="Name"` → generates `<input name="Name" />`
- `HttpPost(ProductFormModel model)` → looks for `Name` in the request
- If names match = the data is automatically populated

**You said:**

In other words, when the form is submitted, the values inside it are matched to the properties or variables in the POST action parameters, and if a match is found, they are automatically bound to those parameters?

**ChatGPT said:**

Yes, exactly! When you submit the form, the **values inside the form** (whether they're from visible fields or hidden inputs) are sent as part of the HTTP request. ASP.NET Core's **model binding** mechanism will then attempt to **find matching properties or variables** in the **post action method parameters** and **bind** the form data to those properties/variables.

**How It Works:**

1. **Form Submission:** When you submit a form, its input fields are sent as part of the HTTP POST body (usually as `application/x-www-form-urlencoded`). For example:

```html
<input name="Id" value="123" type="hidden" />
<input name="Name" value="Product Name" />
<input name="Price" value="19.99" />
```

This results in a POST body like:

```
Id=123&Name=Product+Name&Price=19.99
```

2. **Model Binding:** When the form is posted, ASP.NET Core will **look for matching parameters** in your POST action method. For example, in the method:

```csharp
[HttpPost]
public async Task<IActionResult> Edit(int id, ProductViewModel model)
{
    // model.Id will be 123 (from form data)
    // model.Name will be "Product Name" (from form data)
    // model.Price will be 19.99 (from form data)
}
```

ASP.NET Core will:

- **For the `int id` parameter**, it will look for the `id` value in the form or route (in your case, it can come from the query string or route data if specified).

- **For the `ProductViewModel model` parameter**, it will match the form values (like `Name`, `Price`, etc.) to the properties in the `ProductViewModel` class.

It automatically **binds** form data to the matching properties in the `model` object.

3. **Matching Property Names:** The model binding works based on **matching names**. For instance:

- The form has an input field with `name="Name"`, and in your `ProductViewModel`, there is a property `public string Name { get; set; }`. The form's `Name` value will be bound to `model.Name`.

- If the form has a hidden input field for `Id`, the value of `Id` will be automatically bound to `model.Id`.

4. **Validation:** If you have validation attributes in your model, like `[Required]`, those will also be checked as part of the model binding process. If any validation fails, it will prevent the form data from being processed correctly.

**In Summary:**

- **When the form is submitted**, ASP.NET Core looks for matching **property names** in the method parameters or model.

- If it finds matching names, it **binds the data** (form values) to those parameters/properties.

- The process of **matching and binding** happens automatically, and you don’t have to manually assign values from the request to your model — **this is the power of model binding**.

So, to clarify your question:

- **Yes**, when you submit the form, **model binding** looks for matching properties in the POST method parameters (either directly or via a model like `ProductViewModel`), and it binds the values from the form to the matching properties in the model or method parameters.
# Bookmarks

Completion: 23.04.2025