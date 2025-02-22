# Mappings
## Fluent API

Посочване на Primary Key, като втория вариант е експлицитен и не е препоръчителен:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>()
        .HasKey(s => s.StudentKey);

// Explicitly set Primary Key
    modelBuilder.Entity<Student>() 
        .HasKey("StudentKey");
}

// Composite Key
    modelBuilder.Entity<Car>()
        .HasKey(c => new { c.State, c.LicensePlate });
```

Table и Column настройки:

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
// If an FK property is non-nullable, cascade delete is on by default

modelBuilder.Entity<Course>()
 .HasOne(c => c.Department)
 .WithMany(d => d.Courses)
 .HasForeignKey(c => c.DepartmentID)
 .OnDelete(DeleteBehavior.Restrict); // Throws exception on delete
```
## Attributes
`[Key]` -  посочва primary key.

`[PrimaryKey]` - позволява дефиницията на композитен primary key, наличен от EF7.

`[ForeignKey]` - експлицитно свързваме навигационно пропърти и foreign key пропърти. Няма значение върху кое от двете пропъртита го сложим, винаги трябва да реферира към срещуположното пропърти. EF Core разбира към коя таблица се отнася FK-то въз основа на типа на навигационното пропърти.
`[ForeignKey(NavigationPropertyName)]` – трябва да напишем името на навигационното пропърти в зависимия клас, ако сложим атрибута върху FK пропъртито в зависимия клас.
`[ForeignKey(ForeignKeyPropertyName)]` – трябва да напишем името на FK пропъртито в зависимия клас, ако сложим атрибута върху навигационното пропърти в зависимия клас.
`[ForeignKey(ForeignKeyPropertyName)]` – трябва да напишем името на FK пропъртито в зависимия клас, ако сложим атрибута върху навигационното пропърти в основния клас.

`[Table]` - посочване на името на таблицата в базата данни. Слага се на ниво клас.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
     modelBuilder.Entity<Person>()
         .HasOne(p => p.Passport)  // A person has 0 or 1 passport
         .WithOne(p => p.Person)   // A passport belongs to exactly one person
         .HasForeignKey<Passport>(p => p.PersonId)  // Nullable FK (1:0..1)
         .IsRequired(false);  // Allows null, making it a One-to-Zero-or-One relation
}
```

`[Column]` -  посочване на името на колона в таблицата. Слага се на ниво пропърти. Може да изберем, реда, типа на данните както и други настройки. Чрез `Order`, може да променим реда на колоните, по конвенция EF ги подрежда в реда в, който сме ги написали. `Order` работи само и единствено при създаване на таблицата, ако в последствие променяме структурата, атрибута няма да работи.

```csharp
public class Student
{
    [Column("StudentName", 
              Order = 2, 
              TypeName = "varchar(50)", 
              Nullable = false, 
              MaxLength = 50, 
              Precision = 18, 
              Scale = 2, 
              DefaultValue = "N/A")]
    public string Name { get; set; }
}
```

`[Required]` - задава на колоната да бъде `NOT NULL`. Ако колоната е non-nullable type нaprimer `int`, колоната винаги ще има стойност, дори без да сме сложили този атрибут. Ако не сме сложили стойност, ще бъде сложена стойността по подразбиране за съответния тип.

`[MinLenght]` - задава минималната дължина на колоната от тип `string`. Работи само за client validation.

`[MaxLenght] / [StringLength]` - задават максималната дължина на колоната от тип `string`. Тази настройка е полезна, когато работим с текстови данни и искаме да ограничим дължината на стойностите в колоната. Работи при client и DB validation.

`[Range]` - задава минимален / максимален лимит за числовите пропъртита. Работи само за client validation.

`[Index]` - създава индекс за колона или колони. Primary key винаги има индекс. Това е начинът да направим дадена колона уникална, като използваме параметъра `IsUnique`. Когато в SQL определим дадена колона като `UNIQUE`, автоматично се създава индекс за нея.

```csharp
[Index(nameof(Url))]
public class Student 
{
   public string Url { get; set; }
}

// Using optional arguments
[Index(nameof(Name), IsUnique = true, Name = "ix_TableName_Name_Unique")]
```

`[NotMapped]` - изключва пропъртито от това да се създаде в базата, примерно поради бизнес причини.

```csharp
[NotMapped]
public string FullName => this.FirstName + this.LastName;
```
# Table Relation
## One-to-Zero-or-One
Тази релация се използва рядко в базата данни, тъй като не е логически обоснована. Причината е, че реално имаме един ред, който свързваме с друг ред, което би било по-ефективно, ако първоначално съхраняваме всички данни в един ред, вместо да използваме `JOIN`. От гледна точка на базата данни, разделянето на информацията на части е грешка, когато няма дублиране на данни. В обектно-ориентирания модел обаче това е добра практика, тъй като подобрява четимостта и поддръжката.

**One-to-One (1:1)** 

Когато всяка стойност в едната таблица съответства точно на една стойност в другата. Например, ако всеки човек задължително има ЕГН и всяко ЕГН принадлежи на точно един човек, то това е строго 1:1 релация.

**One-to-Zero-or-One (1:0..1)**

Когато някои записи в едната таблица може да нямат съответствие в другата, но ако имат, то е само едно. Например, ако не всеки човек има паспорт, но ако има, то е точно един, това е 1:0..1 релация.

Разликата се определя от `nullable` външния ключ:
- Ако `passport_id` в таблицата `People` е `nullable`, релацията е 1:0..1.
- Ако `passport_id` е `NOT NULL`, релацията е 1:1.

Ако имаме класовете:

```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Passport Passport { get; set; } // Navigation property
}

public class Passport
{
    public int Id { get; set; }
    public string Number { get; set; }

    public int PersonId { get; set; } // Foreign Key to Person
    public Person Person { get; set; }
}
```

**Attributes:**

В зависимост от кой от двата варианта искаме, трябва да направим Passport пропъртито nullable или не:

**One-to-One** (Person always has a Passport) →  Passport navigation property `NOT NULL`. 
**One-to-Zero-or-One** (Person may have a Passport) → Passport navigation property nullable (Passport?).

Допълнително, трябва да добавим атрибута `[ForeignKey]` над `Person` пропъртито - `[ForeignKey(nameof(PersonId))]`

**Fluent API:**

Tрябва да ползваме `HasOne()` метода:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Person>()
        .HasOne(p => p.Passport)  // One person has 0 or 1 passport
        .WithOne(p => p.Person)   // One passport belongs to exactly one person
        .HasForeignKey<Passport>(p => p.PersonId)  // Nullable FK (1:0..1)
        .IsRequired(false);  // Allows null, making the relationship 1:0..1
}
```

**Обяснение:**

- **`HasOne(p => p.Passport).WithOne(p => p.Person)`** → Дефинира **1:0..1** релация. 
- **`HasForeignKey<Passport>(p => p.PersonId)`** → Дефинира `PersonId` като **nullable** външен ключ.
- **`.IsRequired(false)`** → Позволява `null`, което гарантира **One-to-Zero-or-One** релация.
- Ако искаме **One-to-One (1:1)** релация, трябва да премахнем **`.IsRequired(false)`**, което ще направи `PersonId` **NOT NULL**.

**`.HasOne()`** винаги трябва да бъде комбиниран с друг метод, за да се дефинира напълно релацията. Вторият метод зависи от типа релация:
- **`.HasOne().WithOne()`** – **One-to-One (1:1)**
- **`.HasOne().WithMany()`** – **One-to-Many (1:N)**  
- **`.HasMany().WithOne()`** – **Many-to-One (N:1)**  
- **`.HasMany().WithMany()`** – **Many-to-Many (N:N)**  
## One-to-Many
Това е най-често използваната релация.

Имплементира се чрез създаване на колекция в **parent** таблицата, като не трябва да забравяме да я инициализираме, желателно с `HashSet<T>`.

- The **parent** (e.g., `Department`) е таблицата, която може да има много свързани записи в **child** таблица.
- The **child** (e.g., `Employee`) съдържа външния ключ, който реферира към **parent** таблицата.

Ако имаме класовете:

```csharp
// One department has many employees
public class Department
{
  public int Id { get; set; }
  public string Name { get; set; }

  public ICollection<Employee> Employees { get; set; }
}

// Each employee has one department
public class Employee
{
   public int Id { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
    
   public int DepartmentId { get; set; }
   public Department Department { get; set; }
}
```

**Attributes:**

Трябва да добавим атрибута `[ForeignKey]` над `Department` пропъртито `[ForeignKey(nameof(DepartmentId))]`

**Fluent API:**

```csharp
// HasMany → WithOne / HasOne → WithMany
modelBuilder.Entity<Department>()
  .HasMany(d => d.Employees)
  .WithOne(e => e.Department)
  .HasForeignKey(e => e.DepartmentId);

// Alternativly, achiving the same result:
modelBuilder.Entity<Employee>()
  .HasOne(e => e.Department)
  .WithMany(d => d.Employees)
  .HasForeignKey(e => e.DepartmentId);
```
## Many-to-Many
Когато създаваме релация „много към много“ в базата данни, е необходимо да добавим междинна (mapping) таблица. В EF Core това може да се реализира по два начина:
### Explicit Join Table
Да го направим ръчно, като недостатъка е че колекциите в двете таблици, не са от директните типове, но от типа на свързващата таблица.

- Създаваме свързващ клас, като името му е комбинация от имената на двата класа.
- Този клас има няколко пропъртита - два Foreign Key-a, като е добре да ги направим експлицитно и две навигационни пропъртита за всеки от класовете, с `Id` и типа на класа.
- Трябва да направим композитен Primary Key, като това може да стане с атрибут на ниво клас, но е наличен като опция от EF7. Другата опция е да се направи чрез Fluent API.
- Остава да добавим в двата класа колекция от тип свързващия клас. Ако не го направим, в класовете от примера долу `Student` и `Course` нямаме колекции от типа `List<StudentCourse>`, EF Core автоматично създава скрита (implicit) join таблица, без да я представя като отделен клас. В този случай не можем директно да достъпваме записите от `StudentCourse`, а трябва да направим две отделни заявки. Първо, извличаме всички `CourseId`, които са свързани с даден `StudentId`. След това използваме тези `Id`, за да намерим съответните записи в таблицата `Courses`. Това означава, че вместо да навигираме директно през колекции, разчитаме на релационни заявки.  Ако обаче добавим навигационни колекции (`List<StudentCourse>`) към `Student` и `Course`, можем да използваме `Include()`, което ни позволява да извлечем всички данни само с една заявка. Също така, този подход позволява да добавяме допълнителни данни в join таблицата (например дата на записване, статус и т.н.), но колекциите в `Student` и `Course` са от типа `List<StudentCourse>`, както и получаваме backward compatibility.

Може да се постигне както чрез атрибути, така и чрез Fluent API:

```csharp
public class Student
{
    [Key] // Explicit primary key (not required as EF Core recognizes "Id" by convention)
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigation property - a student can have many records in StudentCourse
    public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

public class Course
{
    [Key] // Primary key
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    // Navigation property - a course can have many records in StudentCourse
    public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

// Explicit join table for the Student-Course relationship using Attributes
[Table("StudentsCourses")] // Specifies the table name
[PrimaryKey(nameof(StudentId), nameof(CourseId))] // Composite Primary Key (introduced in EF Core 7)
public class StudentCourse
{
    // Foreign Key to Student
    public int StudentId { get; set; }

    [ForeignKey(nameof(StudentId))] // Explicitly specifying the foreign key
    public Student Student { get; set; } = null!;

    // Foreign Key to Course
    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))] // Explicitly specifying the foreign key
    public Course Course { get; set; } = null!;
}

// Explicit join table for the Student-Course relationship using Fluent API
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Define the composite primary key using Fluent API
    modelBuilder.Entity<StudentCourse>()
        .HasKey(sc => new { sc.StudentId, sc.CourseId });

    // Define the foreign key relationship for StudentId
    modelBuilder.Entity<StudentCourse>()
        .HasOne(sc => sc.Student) // StudentCourse has one Student
        .WithMany(s => s.StudentCourses) // Student has many StudentCourse records
        .HasForeignKey(sc => sc.StudentId) // Foreign Key
        .OnDelete(DeleteBehavior.Cascade); // Deleting a Student will delete related StudentCourse records

    // Define the foreign key relationship for CourseId
    modelBuilder.Entity<StudentCourse>()
        .HasOne(sc => sc.Course) // StudentCourse has one Course
        .WithMany(c => c.StudentCourses) // Course has many StudentCourse records
        .HasForeignKey(sc => sc.CourseId) // Foreign Key
        .OnDelete(DeleteBehavior.Cascade); // Deleting a Course will delete related StudentCourse records
}

// Тo retrieve a student's courses:
var student = context.Students
    .Include(s => s.StudentCourses)
    .ThenInclude(sc => sc.Course)
    .FirstOrDefault(s => s.Id == 1);

var courses = student?.StudentCourses.Select(sc => sc.Course).ToList();
```
### Implicit Join Table
Да позволим на EF Core да създаде междинната таблица автоматично чрез Fluent API. Недостатъкът на този подход е, че конфигурацията може да бъде сложна, но за сметка на това получаваме директно колекции от двете страни на релацията, което улеснява работата от обектно-ориентирана гледна точка. Друг недостатък е че не можем да добавим допълнителни данни в join таблицата (например оценка).

```csharp
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}

// Mapping both sides of the relationship
builder.Entity<Student>()
    .HasMany(s => s.Courses)
    .WithMany(c => c.Students)
    .UsingEntity<Dictionary<string, object>>(
        "StudentCourse",
        r => r.HasOne<Course>()
              .WithMany()
              .HasForeignKey("CourseId")
              .HasConstraintName("FK_StudentCourse_Courses_CourseId")
              .OnDelete(DeleteBehavior.Cascade),
        r => r.HasOne<Student>()
              .WithMany()
              .HasForeignKey("StudentId")
              .HasConstraintName("FK_StudentCourse_Students_StudentId")
              .OnDelete(DeleteBehavior.Cascade),
        j =>
        {
            j.HasKey("StudentId", "CourseId"); // Composite Primary Key
            j.ToTable("StudentsCourses");
            j.IndexerProperty<int>("StudentId").HasColumnName("StudentId");
            j.IndexerProperty<int>("CourseId").HasColumnName("CourseId");
        });
```
## Multiple Relations
Когато две ентитита са свързани с повече от един Foreign Key, например, когато имаме класовете `Person` и `Town`, в класа `Person` може да имаме две пропъртита като `PlaceOfBirth` и `CurrentResidence`. В класа `Town`, от своя страна, ще имаме две колекции, които отразяват тези връзки. В такъв случай, EF Core може да се затрудни да определи коя колекция отговаря на кой Foreign Key, тъй като и двете колекции съдържат елементи от тип `Person`. За да помогнем на EF Core да установи коректните навигационни връзки, използваме атрибута `[InverseProperty("RelatedPropertyName")]`. Можем да използваме `nameof()`, за да избегнем грешки при изписване на имена, като посочим класа и съответното навигационно свойство. Това гарантира, че ако името на свойството бъде променено, кодът ще остане коректен.

```csharp
public class Person
{
	 public int Id { get; set; }
	 public string Name { get; set; }

	 public int PlaceOfBirthTownId { get; set; }
	 public int CurrentResidenceTownId { get; set; }
	 public Town PlaceOfBirth { get; set; } = null!;
	 public Town CurrentResidence { get; set; } = null!;
}

public class Town
{
	 public int Id { get; set; }
	 public string Name { get; set; }

	 [InverseProperty(nameof(Person.PlaceOfBirth))] // Points toward related property
	 public ICollection<Person> Natives { get; set; } = new HashSet<Person>();

	 [InverseProperty(nameof(Person.CurrentResidence))]
	 public ICollection<Person> Residents { get; set; } = new HashSet<Person>();
}
```
# Bookmarks
[Entity Properties - EF Core | Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt) - Configuration Options for Entity Properties using Data Annotations or Fluent API.