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
## Database Migrations
Обновяване на схемата на базата данни без загуба на данни

 Позволява **добавяне/премахване на таблици, колони** и други промени в схемата.

**Миграциите в EF Core** запазват историята на всички промени във времето.

Различните версии на **ентити класовете** и **DbContext** се проследяват и съхраняват.

Миграциите се **генерират автоматично** чрез инструменти на EF.

Чрез командата `Script-Migration` можем да генерираме **SQL скрипт**, който съдържа всички промени между миграциите. Това е полезно, когато искаме да **прегледаме**, **споделим** или **изпълним ръчно** обновленията на базата данни – особено в production среди, където не използваме директно `database update`.
Скриптът, генериран чрез `Script-Migration`, включва и команда за добавяне на запис в таблицата `__EFMigrationsHistory`. Това означава, че ако го изпълним ръчно върху базата данни (например в SQL Server Management Studio), тя ще се актуализира по същия начин, както ако бяхме използвали `Update-Database` директно от PMC.

За да добавим миграция в EF Core, можем да използваме:

- **EF CLI инструментите:**

```
dotnet ef migrations add {MigrationName}
dotnet ef migrations remove
dotnet ef database update
```

- **Package Manager Console (PMC):**

```
Add-Migration {MigrationName}
Remove-Migration
Update-Database
```

Ако искаме миграциите да се прилагат автоматично при стартиране на приложението, можем да използваме:

```csharp
db.Database.Migrate();
```

За да върнем последната миграция, използваме `Remove-Migration`. За да приложим промените към базата – `Update-Database`.

**Auto Run Migration Scripts at Startup**

```csharp
public class ShoppingListDbContext : DbContext
{
    public ShoppingListDbContext(
        DbContextOptions<ShoppingListDbContext> options)
        : base(options)
        => Database.Migrate();
}
```

Това извикване на `Database.Migrate()` ще приложи всички миграционни скриптове, които още не са били приложени.

Подходящо е за разработка – улеснява синхронизацията на базата с кода.

**Не се препоръчва in production**, може да предизвика проблеми.

Препоръка: в продукционна среда е по-добре да прилагаме миграциите **ръчно** чрез `Update-Database` или SQL скрипт.
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

**You said:**

"`asp-for='Name'` saves us from manually writing the `name` and `value` attributes.  
The tag helper automatically extracts the property's name and value from the model and generates the corresponding HTML for us."

**ChatGPT said:**

Exactly! 💯 That’s **exactly** it — you nailed it.

The `asp-for="Name"` tag helper:

- Looks at your **model's property** called `Name`.
- Automatically sets the:

    - `name` attribute → to `"Name"` (so it can post data correctly).
    - `id` attribute → to `"Name"` (so `<label asp-for="Name">` works).
    - `value` attribute → to the current value of `Model.Name`.


**So this:**

```html
<input asp-for="Name" class="form-control" />
```

Is equivalent to this manually written HTML:

```html
<input type="text" id="Name" name="Name" value="@Model.Name" class="form-control" />
```

Which means:

- You don’t need to repeat yourself.
- You avoid typos like accidentally writing `name="Nam"` or missing the value.
- If you rename the property in your model, Razor updates everything.

It’s like having a smart auto-writer that keeps your HTML synced with your model 👌

`asp-for="PropertyName"` is just a smart shortcut for:

```html
<input 
  name="PropertyName" 
  id="PropertyName" 
  value="@Model.PropertyName"
/>
```

That's **all** it's doing (plus the appropriate `type` if used with `<input>`, `<textarea>`, etc.). But that small thing makes a **huge difference** because:

**✅ Benefits of `asp-for`:**

1. **Strongly typed** – it's tied to your model property. Rename your property in C#, and Visual Studio (or Rider) updates the view too.

2. **Avoids typos** – you won’t accidentally mismatch `name="..."` or forget to set `value`.

3. **Improves maintainability** – you don’t have to update the HTML if the property name changes.

4. **Ensures binding works** – the `name` attribute is the key to model binding in ASP.NET Core.

So even though it's simple, `asp-for` helps keep things clean, safe, and in sync with your model.
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

In other words, when the form is submitted, the values inside it are matched to the properties of objects or variables in the POST action parameters, and if a match is found, they are automatically bound to those parameters?

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
    // id will be 123 (from form data)
    // model.Id will be 123 (from form data)
    // model.Name will be "Product Name" (from form data)
    // model.Price will be 19.99 (from form data)
}
```

ASP.NET Core will:

- **For the `int id` parameter**, ASP.NET Core model binding first tries to bind parameters (like `int id`) from the route, then the query string, then the form data (in that order).

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
## Difference Between Query String, Form Data, and `asp-route`
The key difference between **query string**, **form data**, and **`asp-route`** lies in how data is transmitted during form submission, and how it's bound to controller parameters in ASP.NET Core MVC.

1. **Query String (GET method)**

- **Data Location**: Data is appended to the URL as key-value pairs.

- **Visibility**: Visible in the browser’s address bar.

- **Method**: Uses `GET` method.
    
- **Example**:  
    `/search?query=mouse&category=accessories`

- **When to Use**: Ideal for retrieving data where no server state is changed (e.g., search, filters, pagination).

2. **Form Data (POST method)**

- **Data Location**: Sent in the **body** of the HTTP request.

- **Visibility**: Not visible in the browser’s address bar.

- **Method**: Uses `POST` method.

- **Example**: Form fields like `<input name="name" value="Mouse" />` are submitted as body content.

- **When to Use**: Preferred for sensitive data (e.g., login, payment) or state-changing actions (e.g., create, update, delete).

3. **`asp-route` Attributes**

- **Purpose**: Appends key-value pairs to the **form’s action URL** during HTML generation.

- **Syntax**:

```html
<form asp-action="Delete" asp-route-id="5" asp-route-name="test" method="post">
```

Generates:

```html
<form action="/Product/Delete?id=5&name=test" method="post">
```

- **Location**: Always goes into the **query string**, regardless of method (`GET` or `POST`).

- **Note**:

- These values are not part of the form’s body (`form-data`).

- If the controller is expecting data in the request **body** (for `POST`), these won't be bound unless model binding explicitly maps query strings too (which it often does).

**✅ How They All Work Together**

|Source|Method|Where It Ends Up|Bound To Controller|
|---|---|---|---|
|`asp-route-*`|GET/POST|Query string (URL)|Yes (query binding)|
|Form input controls|GET|Query string (URL)|Yes (query binding)|
|Form input controls|POST|Request body|Yes (form binding)|

**✅ Practical Example:**

```html
<form asp-action="Delete" asp-route-id="5" method="post">
    <input type="hidden" name="name" value="Keyboard" />
    <input type="submit" value="Delete" />
</form>
```

Result:

- `POST` to: `/Product/Delete?id=5`
- In request body: `name=Keyboard`

In controller:

```csharp
[HttpPost]
public IActionResult Delete(int id, string name)
{
    // id from asp-route (query string)
    // name from form body (input field)
}
```

**🔑 Key Takeaways**

- **GET** → query string → visible in URL.

- **POST** → form data → hidden in body.

- `asp-route-*` → always appends to the **URL**, regardless of method.

- If your controller needs a value in POST and you're using `asp-route-*`, it’s better to **also use hidden input fields** for consistency.

**You said:**

So we can build the query string using form controls, which are basically different input elements, or we can use the `asp-route` in the `<form>`, `<a`> or `<button>`, or even hard-code it in the action attribute. However, if it's sent using a GET request, the query string will get ignored. We have to either send it as a POST request, or—if we're using a GET request—instead of building the query string with `asp-route`, we should build it using form controls. That way, the values will not be ignored even in a GET request. Am I correct?

**ChatGPT said:**

Yes, Gerard — you're **spot on**. Here's a breakdown to reinforce and clarify everything you just said:

✅ **Options to pass query string parameters in a form:**

🔹 1. **Form controls** (e.g., `<input name="...">`)

- These are your actual input elements — textboxes, hidden fields, dropdowns, etc.

- When the form is submitted (GET or POST), the browser **generates the query string from them**.

- ✅ **Works reliably with both GET and POST.**

- Example:

```html
<form method="get" action="/Product/Delete">
    <input type="hidden" name="name" value="Phone" />
    <input type="submit" />
</form>
```

➜ Results in: `/Product/Delete?name=Phone`

🔹 2. **asp-route-... attributes**

- This is Razor's syntax for **building the `action` URL with route/query parameters**.

- They don’t generate input fields — they just produce a URL with the right query string when the page is rendered.

- ✅ Great when you don’t want to rely on user input (e.g., hardcoded parameters).

- ❗ **Only useful when the browser uses the full action URL** during submission.

✅ Works for:
    
- `<a>` links

- Forms with `asp-action` and **POST** requests

❌ Problem:

- When the form is `method="get"` and **you rely only on `asp-route-*`**, the browser **does not include them again when submitting** — it just takes form controls.

🔹 3. **Hardcoding the full URL in `action`**

- You can manually set `action="/Product/Delete?id=5&name=Phone"`

- ❗But if you don’t have form inputs named `"id"` and `"name"`, nothing new gets added — the browser just uses the URL as-is.

**🔥 So to summarize your conclusion:**

> ✅ You're **correct** that when submitting a `GET` form, the browser will ignore any query string in the action and build a new one **only** from form controls.

> ✅ If you want to pass data in a GET form **reliably**, use:

- `<input type="hidden" name="...">` or other form inputs

- **Don’t rely solely on `asp-route-*`** unless the method is POST

> ✅ On `POST` forms, `asp-route-*` works because Razor builds the `action` with query string, and the browser keeps it.
## Route Parameter / Query String / asp-route-*
The difference between using a **route parameter** or a **query string** depends on how your routes are configured in your `MapControllerRoute` in `Startup.cs` (or `Program.cs` for .NET 6+).

Here's a breakdown:

**1. Query String** (using `asp-route-*`):

When you use `asp-route-*`, the value gets added as a **query string** parameter. This happens when your route doesn't explicitly define a parameter in the URL pattern (path).

For example, if you have a route like this:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");
});
```

And you use `asp-route-*` in the anchor tag like this:

```html
<a asp-controller="Product" asp-action="Add" asp-route-name="gadgets" class="btn btn-primary">Add Product</a>
```

It will generate a URL like:

```
/Product/Add?name=gadgets
```

Here, the value (`gadgets`) is part of the **query string**.

**2. Route Parameter** (path in URL):

If you want the value to be part of the **URL path** (as a route parameter), your route pattern needs to explicitly define the parameter in the path.

For example:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "productRoute",
        pattern: "Product/Add/{name}");
});
```

In this case, the `{name}` part in the route is a **route parameter**, and it will be part of the URL path.

Then, you can link to it like this:

```html
<a asp-controller="Product" asp-action="Add" asp-route-name="gadgets" class="btn btn-primary">Add Product</a>
```

This will generate a URL like:

```
/Product/Add/gadgets
```

Here, the value (`gadgets`) is part of the **URL path**, not the query string.

**Key Point:**

In both cases, the `asp-route-*` tag helper is responsible for generating the correct `href` link in the resulting HTML. It dynamically builds the URL based on the route configuration and any parameters you specify in the Razor page.

- **If the route is defined with a path parameter** (e.g., `/Product/Add/{name}`), `asp-route-*` will insert the parameter value directly into the URL path.

- **If the route uses a query string**, the tag helper will create a URL with the parameter as a query string (e.g., `/Product/Add?name=gadgets`).

**Summary:**

- **Query String**: If you use `asp-route-*` and there's **no route parameter** in your route pattern (or the parameter doesn't match the route configuration), the value gets added as a **query string** in the URL (e.g., `/Product/Add?name=gadgets`).

- **Route Parameter**: If you have a **route pattern** that defines a parameter (like `/Product/Add/{name}`), and the `asp-route-*` value matches the name of that route parameter, the value will be part of the **URL path** (e.g., `/Product/Add/gadgets`).

- Whether it's part of the path or a query string, the `asp-route-*` tag helper ensures that the correct URL is generated based on the parameters and the route configuration you have in your controller.

In short, whether you get a query string or a route parameter depends on how your route is defined in the routing configuration and whether the `asp-route-*` matches the route parameter in the URL path.
## `<a>` vs `<input>`
If you want your `<a>` tag (which generates a **GET** request) to send **multiple query string parameters**, just add multiple `asp-route-*` attributes — one for each key-value pair. ASP.NET will convert them into a query string automatically.

**✅ Example: Passing multiple parameters**

```html
<a asp-controller="Product" 
   asp-action="Add" 
   asp-route-name="test" 
   asp-route-price="999" 
   asp-route-category="Phones" 
   class="btn btn-primary">
   Add Product
</a>
```

**🔍 Resulting HTML:**

This will render as:

```html
<a href="/Product/Add?name=test&price=999&category=Phones" class="btn btn-primary">Add Product</a>
```

And your controller can catch those like this:

```csharp
[HttpGet]
public IActionResult Add(string name, decimal price, string category)
{
    // name = "test"
    // price = 999
    // category = "Phones"
    return View();
}
```

So just repeat `asp-route-` for every value you want to send 🎯 Let me know if you want to try the same thing but using **routes** instead of query strings.

**🟦 1. HTML `<input>` elements in forms**

These are used in **POST** requests (usually), and each `<input>` creates **one name-value pair** that goes into the form body.

✅ For example:

```html
<form method="post">
    <input name="Name" value="Phone" />
    <input name="Price" value="999" />
    <input name="Category" value="Electronics" />
    <button type="submit">Submit</button>
</form>
```

This creates a **POST body** like:

```
Name=Phone&Price=999&Category=Electronics
```

Each `input` provides **one** pair. You can’t put two pairs in one input — that’s why you need separate inputs.

**🟦 2. `<a>` tag using `asp-route-*`**

These generate **GET** requests with query strings. And in this case, you're not limited by HTML rules — you're just building a URL.

✅ For example:

```html
<a asp-action="Add" asp-route-name="Phone" asp-route-price="999">Add Product</a>
```

This becomes:

```html
<a href="/Product/Add?name=Phone&price=999">Add Product</a>
```

So here, the `asp-route-*` attributes are just **Razor helpers** that let you attach multiple query string parameters into the generated link.

**⚖️ In summary:**

- `<input>` is **form data**, 1 input = 1 name-value pair.
- `asp-route-*` is for **building URLs** on `<a>` or `<form>` actions, and you can add as many as you want.

They serve different purposes and follow different rules, but both eventually become name-value pairs in different parts of the HTTP request (form body vs query string).

**ASP.NET Core Tag Helpers Cheat Sheet**

|Feature|`asp-for`|`asp-route-*`|
|---|---|---|
|**Purpose**|Binds input fields to model properties|Adds query string parameters to links or form actions|
|**Works on**|`<input>`, `<textarea>`, `<select>`, etc.|`<a>`, `<form>`, `<button>` (used for URL generation)|
|**Generates**|`name` and `value` attributes for inputs|Adds `?key=value` to the `href` or `action`|
|**Example**|`<input asp-for="Name" />`|`<a asp-route-id="5" asp-route-name="item" />`|
|**Output**|`<input name="Name" value="..." />`|`<a href="/controller/action?id=5&name=item">`|
|**Usage**|Used in forms for POST/GET binding|Used in links to send values via query string|
|**Not Valid On**|`<a>`, `<button type="submit">`|`<input>`, `<textarea>`, `<select>`|

If you're ever not sure:

- Think **model binding** = `asp-for`
- Think **URL building** = `asp-route-*`
## Data Transmission in Web Requests: URL vs. Body Based on HTTP Method and Form Elements
To simplify thinking about data transmission in web requests, it's key to focus on **where the data is sent** and **how it's transmitted**, depending on:

1. **HTTP Method** (GET vs POST)
    
    - **GET**: Data is usually sent **in the URL** as query string parameters. This means the data is visible in the browser's address bar.
        
    - **POST**: Data is sent **in the request body**, which is not visible in the browser's address bar. However, query string parameters can still be added to the URL (e.g., with `asp-route-*`).
        
2. **Form Elements** (form controls vs `asp-route-*`)
    
    - **Form Controls**: When you use form elements like `<input>`, `<select>`, or `<textarea>`, the data is sent as part of the **body** in a **POST** request.
        
        - **For `GET` requests**, form data **is automatically added to the URL as query string parameters**. This happens because `GET` request data is **sent in the URL**.

    - **`asp-route-*`**: These **always add data to the URL** as query string parameters, regardless of whether it's a GET or POST request.

**Key Concepts:**

- **GET Method**: Data in the URL (query string). Only **query string parameters** are visible.
    
- **POST Method**: Data in the body of the request, **form data** is hidden from the URL but still visible in the request body.
    
    - You can **combine form data with query string parameters** (via `asp-route-*`) for **POST** requests, but the query string is still visible in the URL.

**In summary:**

- When designing forms or links, it's important to know:
    
    - **Where your data will appear**: in the **URL** (query string) or in the **body** of the request.
        
    - **Which HTTP method** will be used (GET vs POST).
        
    - Whether you're using **form controls** or **asp-route attributes** to add parameters.

This helps ensure you understand **where your data is going** and **how it's visible** to the browser and server, depending on your choices.

**You said:**

Basically, the whole idea of the POST and GET methods is to send data from the client to the server, where this data is structured as key-value pairs.

**ChatGPT said:**

Yes, exactly — you're right on point!

At the core, **HTTP GET and POST methods** are just two ways of **sending key-value pairs between the client and the server**, but they differ mainly in **how** and **where** the data is sent.

✅ **GET Method** – _Data in the URL (query string)_

- Sends **key-value pairs** in the **URL**, after a `?`, like:

```
/products?category=books&page=2
```

- Data is **visible** in the address bar.
    
- **Limited length** due to URL size limits.
    
- Typically used for:
    
    - Searching
    - Filtering
    - Navigation
    - Anything that doesn’t change server state (i.e., is safe/idempotent)

✅ **POST Method** – _Data in the Request Body_

- Sends **key-value pairs** in the **body** of the request.

- Data is **not visible** in the address bar.

- **No practical size limit** for most use cases.

- Used when:

    - Submitting forms (login, register, upload)
    - Changing data on the server (creating/editing/deleting)

**👀 Example Comparison**

**GET Example:**

```html
<form method="get" action="/search">
  <input type="text" name="query" value="shoes">
  <input type="submit">
</form>
```

➡️ Submits as:  
`/search?query=shoes`

POST Example:

```html
<form method="post" action="/checkout">
  <input type="text" name="productId" value="123">
  <input type="submit">
</form>
```

➡️ Submits to `/checkout`, but the data (`productId=123`) is in the body.

**🎯 Summary**

|Feature|GET|POST|
|---|---|---|
|Data Location|URL query string|Request body|
|Visibility|Visible in address bar|Hidden from user|
|Size Limit|Yes|Not really|
|Used For|Read/query/filter actions|Create/update/delete actions|
|Bookmarkable|Yes|No|

So yes — **both methods are about transferring key-value pairs**, but the main difference is where those pairs travel and how they are handled.
## Choosing Between GET and POST in HTML Forms: Usage, Behavior, and Best Practices
Forms are typically used with the **POST** method when submitting data that should modify the server's state or when dealing with sensitive information, like passwords. This is because **POST** requests send the data in the **body** of the request, making it more secure for sensitive data and allowing larger amounts of data to be submitted.

However, forms **can** be used with the **GET** method, although it's less common. In this case, the form data is sent as part of the **query string** in the URL, which can be visible in the browser's address bar. This is usually used for **retrieving** data without changing the server's state. Some examples might include:

- **Search forms**: Where the parameters are passed in the URL to filter results.
- **Navigation**: For example, selecting a category from a list of products and showing the filtered results.

**When to Use GET vs POST in Forms**

- **GET**: Use when you're **retrieving** data or performing **non-state-changing operations**, such as:
    
    - Displaying results from a search query.
    - Navigating between pages.
    - Filtering data.
    
    Since the form data is appended to the URL as a query string, it's visible and limited in length (usually 2048 characters). For **non-sensitive** data and **simple queries**, GET is fine.
    
- **POST**: Use when you need to **send data that might change the server's state**, such as:
    
    - Submitting a form to create or update a record (e.g., a product, user profile).
    - Sending sensitive information (e.g., login credentials).
    - Uploading files.
    
    With POST, the form data is sent in the body of the request, and it's **not visible in the URL**, making it more suitable for larger and more sensitive data.

**Example Scenarios:**

1. **GET Form**: (e.g., Search or Filter)

```html
<form method="get" action="/Search">
    <input type="text" name="query" placeholder="Search for a product" />
    <input type="submit" value="Search" />
</form>
```


This would result in a URL like `/Search?query=laptop`, which can be bookmarked or shared.

2. **POST Form**: (e.g., Submitting a Product)

```html
<form method="post" action="/Products/Create">
    <input type="text" name="name" placeholder="Product name" />
    <input type="submit" value="Create Product" />
</form>
```

This would send the product data in the body of the request to be processed by the server.

**Summary:**

- **GET** is more commonly used for forms that **retrieve** data (e.g., search, filters), where the parameters are passed as part of the URL.
- **POST** is more commonly used for forms that **create, update, or delete** data, where the data is sent in the body of the request for better security and larger payloads.

While using forms for **GET** requests is valid, it's less typical since **GET** is generally used for operations where the data is not modifying the server's state.
# Bookmarks
Completion: 24.04.2025