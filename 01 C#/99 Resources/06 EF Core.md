# Mappings
## Fluent API
Мапингите в `OnModelCreating()` изглеждат по следния начин:

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
# Bookmarks
[Entity Properties - EF Core | Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt) - full Configuration Options for Entity Properties using Data Annotations or Fluent API.