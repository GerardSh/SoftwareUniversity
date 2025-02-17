# General
## Object Composition
Object composition е включен в тази тема, тъй като представлява механизъм за описване на релациите в EF Core.

Когато описваме по-сложен обект, разполагаме с два подхода:

- Inheritance – един обект може да наследи друг, добавяйки допълнителни пропъртита и функционалности. Обозначава релация от типа „is-a“ – например, спортен автомобил е автомобил.
- Object composition – обозначава релация от типа „has-a“ – например, автомобилът има двигател. Ако решим да сложим всички пропъртита на двигателя директно в класа Car, това ще доведе до:
    - Нарастване на сложността – ако автомобилът има много компоненти (двигател, колела, интериор и т.н.), класът ще стане прекалено голям и труден за управление.
    - Нарушаване на принципа на единствената отговорност (SRP) – класът Car ще отговаря за твърде много неща, вместо да е фокусиран само върху поведението на автомобила.
    - По-малка гъвкавост – ако добавим различни видове двигатели (например електрически или бензинов), ще трябва постоянно да променяме класа Car, вместо просто да заменим обект от тип Engine.

Съществува дизайнерски принцип, според който object composition е за предпочитане пред inheritance, тъй като осигурява по-ясна структура и по-добра организация на кода. В същността си няма разлика дали всички пропъртита се намират в един обект или са разпределени в съставни обекти – обемът на информация остава същият, но композицията улеснява управлението и разширяемостта на кода.
### Navigation Properties
Тези пропъртита създават релацията между ентитетите и са част от object composition. Например, когато имаме студент и курсове, студентът притежава колекция от курсове, която представлява навигационно пропърти. Чрез нея можем да достъпим всички курсове, в които студентът е записан. По аналогия, даден курс също притежава колекция от студенти, записани в него.

Чрез тези пропъртита, може много бързо да достъпим информация за дадено ентити. ET използва релациите в базата данни и върху всеки foreign key в базата, се създава индекс за да ускори четенето по тези връзки.

Може да променяме стойностите на свързаните обекти чрез навигационните пропърти. Например, ако имаме двама студента, които са записани в един и същи курс и ги заредим чрез EF, ако променим нещо по курса на единия студент, тези промени ще се отразят и за всички други студенти, които са записани в същия курс. Това се случва, защото самият курс е същият обект, свързан с всеки студент и EF следи релациите между обектите. Когато направим промени, не само студентите ще бъдат обновени в базата данни, но и всички свързани обекти и колекции, включително тези по навигационни пропърти.

Ако добавим нов студент към колекцията му със студенти на даден курс, това ще създаде нов студент в базата данни. За да се направи така връзка, това няма как да се случи преди да съществува самия обект, защото ни трябва ID на студента, съответно EF знае последователността в която трябва да insert-не въпросните записи по таблиците, да получи Id-тата им и след това да ги навърже в съответната релация.

Основната идея е, че не е нужно да зареждаме всяко едно ентити поотделно, за да го променим. Ако имаме връзка между обектите и ги заредим заедно, можем да ги редактираме и чрез извикване на `SaveChanges()` промените ще бъдат записани в базата данни. EF автоматично ще отрази тези промени за всички свързани обекти.
#### Entity References
- **Entity Reference (One-to-One)**: Един към един (единично съществуване на връзката).
- **`ICollection` (One-to-Many)**: Един към много (единични записи от едната страна, колекция от другата).
- **`ICollection` (Many-to-Many)**: Много към много (колекции от двете страни).
##### (One-to-One or Zero)
- Това е когато една таблица има референция към точно една друга таблица или нула.
- Пример: Всеки човек има един паспорт. 

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Passport Passport { get; set; }  // One-to-One
}

public class Passport
{
    public int Id { get; set; }
    public string Number { get; set; }
}
```

- **Person** има референция към **Passport** и тази връзка може да бъде нула (т.е. човекът може да няма паспорт).
- **Passport** няма колекция от хора, защото всеки паспорт принадлежи само на един човек.
##### `ICollection` (One-to-Many)
- Това е когато една таблица има много записи от друга таблица, но не и обратно.
- Пример: Един град има много хора, но един човек е свързан с един град.

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? CityId { get; set; }
    public City City { get; set; }  // One-to-Many
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Person> People { get; set; }  // One-to-Many
}
```
##### `ICollection` (Many-to-Many)
- Това е когато две таблици имат много записи, свързани помежду си.
- Пример: Един студент може да е записан в много курсове и един курс може да има много студенти.

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }  // Many-to-Many
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; }  // Many-to-Many
}
```
## Fluent API
Code First – когато пишем код, на базата на който Entity Framework генерира база данни, нашите POCO (Plain Old CLR Objects) класове се мапват към таблици, използвайки набор от конвенции. Освен тези конвенции, може да накараме EF експлицитно да извършва дадени действия, като това е препоръчителният вариант.
- Пропърти с име "Id" се мапва като Primary Key.

Конвенциите имат по-нисък приоритет и се използват, само ако няма конфигурирани настройки, чрез Fluent API или data annotations.

Fluent API (Model Builder) позволява пълен контрол над DB мапингите:
- Може да наименуваме всички обекти, без значение дали са колони, таблици, sequences и тн.
- Валидации и типове данни. Валидациите, направени чрез Fluent API, ще работят винаги в базата данни, докато валидациите, направени чрез data annotations, могат да не бъдат приложени към базата данни, в зависимост от типа на валидацията. Например, валидации за дължина или диапазон на стойности, направени чрез data annotations, могат да не се прехвърлят директно в SQL скриптовете на базата данни.
- Дефиниране на сложни връзки между обектите.
### Working with Fluent API
Custom мапингите се извършват в метода `OnModelCreating()`, който е част от класа `DbContext`. Трябва да го override-нем и вътре в него, като използваме `ModelBuilder`, за да конфигурираме базата данни. EF автоматично предоставя `ModelBuilder` като аргумент на метода. Това се случва вътрешно, когато EF инициализира `DbContext`. При стартиране на приложението EF създава инстанция на `DbContext` и извиква `OnModelCreating()`, като подава `ModelBuilder`, който съдържа API за конфигуриране на моделите.
#### Mappings
Мапингите в `OnModelCreating()` изглеждат по следния начин:

Посочване на Primary Key, като втория вариант е експлицитен и не е препоръчителен:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>()
        .HasKey(s => s.StudentKey);

// Explicitly set Primary Key
    modelBuilder
        .Entity<Student>() .HasKey("StudentKey");
}
```

Промяна на имената на DB обекти - таблици, колони, както и схемата, в която се намира дадена таблица. Стандартната схема е `dbo`, но може да се създаде нова схема и да се съхраняват таблиците там. Имената на колоните също могат да бъдат променяни, като често се налага това при използване на запазени думи в SQL, например `Name`. Чрез метода `Property()` можем да променяме различни аспекти на колоната, като име и тип на данните. В project file-a - `.csproj` имаме `<Nullable>enable</Nullable>`, като ако е `enable` това означава, че използваме новия вариант с nullable data types, всички референтни типове не могат да бъдат `null`. Примерно типа `string`, не е nullable (компилатора дава warning, ако опитаме да му присвоим стойност `null`), трябва да кажем че е nullable, като ползваме `?` след типа на пропъртито или променливата - `public string? Name { get; set; }`.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
// Specifying Custom Table name
modelBuilder.Entity() 
  .ToTable("OrderRef", "Admin"); // Optional schema name

// Custom Column name/DB Type
modelBuilder.Entity<Student>()
 .Property(s => s.Name)
 .HasColumnName("StudentName")
 .HasColumnType("varchar");

// Other column attributes
 .HasMaxLength(50)
 .IsRequired();
 .ValueGeneratedOnAdd();
 .ValueGeneratedOnUpdate();
 .ValueGeneratedOnAddOrUpdate();
}
```

Може да изключим пропърти от това да се създаде в базата, примерно поради бизнес причини, както и да определяме политиката за cascade:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
modelBuilder
	.Entity<Department>()
    .Ignore(d => d.Budget);
}

// Disabling cascade delete
// If a FK property is non-nullable, cascade delete is on by default

modelBuilder.Entity<Course>()
 .HasRequired(t => t.Department)
 .WithMany(t => t.Courses)
 .HasForeignKey(d => d.DepartmentID)
 .OnDelete(DeleteBehavior.Restrict); // Throws exception on delete
```
# Misc
## `ModelBuilder` Class
Този клас както и всички builder класове, позволяват да конфигурираме обекта, който build-ваме. `ModelBuilder` класът е много полезен инструмент за конфигуриране на модели в EF Core, като предоставя много опции за конфигурация на базата данни. Той ни позволява да зададем точни настройки за нашите ентитита, да определяме правила за валидация и да изграждаме релации между таблиците в базата данни, използвайки Fluent API.
# ChatGPT
## Many-to-Many Relationship and Collection Representation
In a many-to-many relationship, such as between **Students** and **Courses**, SQL queries typically return all possible combinations of associated records. For instance, if a student is enrolled in 4 courses, a **JOIN** query would produce 4 records, each representing one combination of the student and a course. The result might look like this:

**SQL Query Result Example:**

|Student Name|Course Name|
|---|---|
|John Doe|Math 101|
|John Doe|Physics 101|
|John Doe|History 101|
|John Doe|Computer Science|

In this case, **John Doe** appears **4 times**, once for each course he is enrolled in, with the only difference being the course name.

In **Object-Oriented Programming (OOP)**, this would be translated into a **collection** of 4 elements. Each element in the collection represents a course that the student is enrolled in. This collection holds the exact same number of combinations (4) that were returned by the SQL query, reflecting the many-to-many relationship between the student and their courses.

Thus, the **number of combinations** retrieved by the SQL query corresponds to the **number of elements in the collection** in OOP that the **student instance** will have. Each element in the collection represents one of the student's enrolled courses, reflecting the many-to-many relationship between the student and the courses.
## Tracking vs. Non-Tracking Queries
When we perform nested selects, we execute a query to retrieve the required data and project it into a new collection in memory. However, this data is not tracked by the context. If we want to maintain tracking of the entities, should we use `Include` to achieve that?

**ChatGPT said:**

Exactly! When you use a projection (like `.Select(e => new { ... })`), you're doing the following:

- ✅ **Defining a shape** for the data that should be retrieved from the database.
- ✅ **Executing the query in SQL**, meaning only the necessary columns are fetched.
- ✅ **Loading the data into memory** as an anonymous object or DTO (Data Transfer Object).
- ✅ **Losing tracking** because the result is not an entity, but just a snapshot of data.

**Using `.Select(...)` (Projection) – NOT Tracked**

```csharp
var employees = context.Employees
    .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                              && ep.Project.StartDate.Year <= 2003))
    .Select(e => new
    {
        FirstName = e.FirstName,
        LastName = e.LastName,
        Projects = e.EmployeesProjects.Select(ep => new
        {
            ProjectName = ep.Project.Name,
            StartDate = ep.Project.StartDate
        })
    })
    .ToList();
```

- ✅ **Efficient query**: Only the required columns are fetched.
- ❌ **Not tracked by EF Core**: The returned objects are not entities, just snapshots of data.
- ❌ **Cannot modify and persist changes**: You cannot modify the employees or projects and expect changes to be saved with `context.SaveChanges()`.

**Using `.Include(...)` – Tracked**

```csharp
var employees = context.Employees
    .Include(e => e.EmployeesProjects)
    .ThenInclude(ep => ep.Project)
    .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                              && ep.Project.StartDate.Year <= 2003))
    .ToList();
```

- ✅ **EF Core tracks these objects**: Any modifications to them will be persisted.
- ✅ **Complete data structure**: The relationships (e.g., `e.EmployeesProjects`) are preserved.
- ❌ **Less efficient query**: The query loads entire objects, which might be less efficient if only a few fields are needed.

**When to Use Each Approach**

| Scenario                                           | **Use Projection (.Select)** | **Use `.Include` (Tracking)** |
| -------------------------------------------------- | ---------------------------- | ----------------------------- |
| Read-only data (e.g., API response, UI)            | ✅ Yes                        | ❌ No                          |
| Modifying entities (e.g., `context.SaveChanges()`) | ❌ No                         | ✅ Yes                         |
| Need only a few properties                         | ✅ Yes                        | ❌ No                          |
| Need full objects with navigation props            | ❌ No                         | ✅ Yes                         |
| Large datasets (performance-sensitive)             | ✅ Yes                        | ❌ No                          |
## Fluent API and Data annotations Reflection Usage
Fluent API does not rely on reflection for its configuration. It uses explicit method calls to configure models, relationships, and constraints during the `OnModelCreating` process. Reflection is only needed when Data Annotations are used, as EF Core relies on reading the attributes applied to the classes and properties to determine the configuration. With Fluent API, the configuration is done directly in code, avoiding the need for reflection.
## Fluent Interface
**Fluent Interface** is a design pattern that allows chaining method calls by having each method return an object that supports the next method.

For example, the `modelBuilder.Entity<Student>().HasKey(s => s.StudentId);` is using the **Fluent Interface** pattern, which allows method chaining. This is why you can keep calling methods like `HasKey()` on the result of `modelBuilder.Entity<Student>()`. Let me break this down further:

In this case, the method **`Entity<Student>()`** returns an object that has a method **`HasKey()`**, and **`HasKey()`** returns the same object, enabling further method calls like `HasIndex()`, `Property()`, etc.

**How it Works in EF Core**

- `modelBuilder.Entity<Student>()` returns an `EntityTypeBuilder<Student>`, which has methods for configuring the `Student` entity.
- `HasKey()` is a method of `EntityTypeBuilder<Student>`, which **returns `EntityTypeBuilder<Student>` again**, allowing you to chain more calls.

So, the syntax works because each method in the chain is returning the same builder object, which allows you to keep calling methods.

**Example of Method Chaining in EF Core:**

```csharp
modelBuilder.Entity<Student>()
    .HasKey(s => s.StudentId)  // Defines the primary key
    .HasIndex(s => s.Email)    // Adds an index on the "Email" property
    .Property(s => s.Name)     // Configures the "Name" property
    .IsRequired();             // Makes "Name" required
```

**Why Does This Work?**

Each method in the chain returns the same object (`EntityTypeBuilder<Student>`), so you can continue calling other configuration methods on it.

- **`EntityTypeBuilder<Student>`** is a strongly-typed builder object used to configure the `Student` entity.
- Methods like `HasKey()`, `HasIndex()`, etc., return the builder object itself, which is why chaining is possible.

**Summary**

- **`modelBuilder.Entity<Student>()`** returns an object (an instance of `EntityTypeBuilder<Student>`).
- **`HasKey()`** and other methods in the fluent chain return the same `EntityTypeBuilder<Student>` object, allowing the fluent interface pattern to work and enabling method chaining.
## Nullable Reference Types and EF Core
Let's break down the concept of nullable reference types in C# and how it affects a property like `string Name` in your `Student` class, depending on whether nullable reference types are enabled or disabled at the project level.

**Nullable Reference Types Enabled (`#nullable enable`)**

When **nullable reference types are enabled** at the project level (or via `#nullable enable` in a specific file), C# introduces stronger checks to determine whether reference types (like `string`, `class`, etc.) can be `null`.

**Behavior for `string Name`**:

- If you declare `public string Name { get; set; }`, **C# assumes that `Name` cannot be `null`**.
- The compiler will give you a warning if you try to assign `null` to `Name` (unless it’s explicitly marked as nullable).

This means that when **nullable reference types are enabled**, the `string Name` property is **non-nullable by default**. It is assumed that the property will always have a valid `string` value, and `null` is not allowed unless the compiler sees a specific nullable annotation (i.e., `string?`).

For example, in this case:

```csharp
public class Student
{
    public string Name { get; set; }  // Non-nullable string
}
```

- **`Name` cannot be assigned `null`**.
- If you try to assign `null` to it, the compiler will give you a warning: `"CS8600: Converting null literal or possible null value to non-nullable reference type."`

However, **nullable reference types allow you to opt-out** of this behavior by marking the property as nullable:

```csharp
public class Student
{
    public string? Name { get; set; }  // Nullable string
}
```

Now, **`Name` can be assigned `null`**, and the compiler won't give a warning because it knows that `Name` is allowed to be `null`.

**Nullable Reference Types Disabled (`#nullable disable`)**

When **nullable reference types are disabled** (which is the default for C# projects before version 8.0), **all reference types are implicitly considered nullable**. This means that the compiler doesn't enforce any rules about whether a reference type can be `null` or not.

**Behavior for `string Name`**:

- With nullable reference types **disabled**, a `string` property (like `Name`) is implicitly considered **nullable**, meaning it can be `null` without the compiler issuing any warnings.
- In this case, you could assign `null` to `Name` without any issue:

```csharp
public class Student
{
    public string Name { get; set; }  // Nullable string by default
}
```

- The compiler doesn't warn you when you assign `null` to `Name` because it considers it nullable by default, and it won't perform any nullability checks.

So, when nullable reference types are **disabled**, you don't get compile-time warnings, and all reference types (like `string`) are treated as if they can be `null`.

**Summary of Differences**

|**Nullable Reference Types**|**Property Type**|**Effect on `string Name`**|
|---|---|---|
|**Enabled (`#nullable enable`)**|`string`|**Non-nullable** by default. The compiler will warn if you assign `null`.|
|**Enabled (`#nullable enable`)**|`string?`|**Nullable**. You can assign `null` without warnings.|
|**Disabled (`#nullable disable`)**|`string`|**Nullable** by default. You can assign `null` without warnings.|

**In Practice**

- **When nullable reference types are enabled**, it's **explicitly clear** whether a property can be `null` or not. If you don't want a property to be nullable, you mark it as non-nullable (`string`), and if you want it to be nullable, you mark it as nullable (`string?`).

- **When nullable reference types are disabled**, all reference types are implicitly nullable, and you don't get any warnings for `null` assignments.

**In Entity Framework (EF)**

When nullable reference types are enabled or disabled, it can affect how you configure properties in EF, especially regarding the database schema (whether a column allows `NULL` values).

- With **nullable reference types enabled**, EF can automatically infer the nullability of columns based on whether you declare a property as `string` (non-nullable) or `string?` (nullable).
- With **nullable reference types disabled**, EF assumes reference types are nullable, unless specified otherwise.

**Nullable Reference Types Summary**:

- **Nullable (`string?`)**: Allows a `null` value to be assigned to a reference type.
- **Non-nullable (`string`)**: The reference type cannot be assigned `null`. If nullable reference types are **enabled** in the project, this means the compiler will warn you when trying to assign `null` to a non-nullable property.

**Relation to EF Core**:

EF Core respects the **nullable reference types** setting, but it also allows additional control through configuration.

- **`IsRequired()` Method**:
    - **When EF Core creates the database schema**, it checks whether the property is nullable or required.
    - **If `IsRequired()` is called** on a property, EF Core will create a `NOT NULL` constraint in the SQL database, regardless of whether nullable reference types are enabled at the code level.
    - **If `IsRequired()` is not called**, EF Core will treat the property as nullable in the database (unless it is explicitly defined as non-nullable via data annotations or Fluent API).

**When `IsRequired()` Will Create a `NOT NULL` Constraint**:

- **Explicitly** called on a property (`.IsRequired()`).
- **Non-nullable reference types** in C# code: Even if nullable reference types are enabled in the project, EF Core will still enforce the `NOT NULL` constraint when `IsRequired()` is used.

**When `IsRequired()` Will Not Create a `NOT NULL` Constraint**:

- **If `IsRequired()` is not used**.
- **Nullable reference types**: If the property is defined as nullable (either with `?` or by project-level settings), EF Core will not enforce a `NOT NULL` constraint in the database unless explicitly configured.

**Summary**:

- **Nullable**: A property can accept `null`.
- **Non-nullable**: A property cannot accept `null`, enforced by compiler warning with nullable reference types enabled.
- **`IsRequired()` in EF Core**: Always generates a `NOT NULL` constraint in the database, regardless of the C# nullability configuration.
- **`?` (Nullable Reference Type)**: Makes the property nullable in the code, which means the property can hold `null` values. If the property is nullable (`string?`), it will allow `NULL` in the database unless overridden by `IsRequired()`, which enforces the `NOT NULL` constraint.
    
- **Project-level Nullable Option (Nullable Reference Types enabled)**:
    - **If enabled**: Properties are treated as non-nullable by default (e.g., `string`), and nullable reference types (e.g., `string?`) can be assigned `null`.
    - **Even with nullable reference types enabled**, **EF Core will not automatically generate a `NOT NULL` constraint** in the database unless `IsRequired()` is used.

**Final Conclusion:**

- **`IsRequired()`** will **always** enforce a `NOT NULL` constraint in SQL.
- The `?` operator makes a property **nullable** in both code and database unless overridden by `IsRequired()`.
- **Project-level nullable settings** impact how the code behaves, but **EF Core needs `IsRequired()`** to enforce `NOT NULL` constraints in the SQL schema.
- In essence, the only way to enforce **`NOT NULL`** constraints in the SQL database schema is by using the **`IsRequired()`** method in the Fluent API or by applying the **`[Required]`** attribute from data annotations to the property.
## EF Core Change Tracking and Validation
- **Tracking Changes**: EF Core tracks entity changes but doesn’t validate against database constraints immediately.
- **Validation on Save**: Validation occurs only when `SaveChanges()` is called, checking against database constraints (e.g., `NOT NULL`, `UNIQUE`).
- **Error Handling**: If constraints are violated, exceptions like `DbUpdateException` or `SqlException` are thrown during the save process.
- **No Immediate Errors**: No errors are raised when changes are made, only during the save operation if the constraints are violated.
# Bookmarks
Completion: 18.02.2025