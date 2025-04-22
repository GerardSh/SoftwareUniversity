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
# Bookmarks

Completion: 23.04.2025