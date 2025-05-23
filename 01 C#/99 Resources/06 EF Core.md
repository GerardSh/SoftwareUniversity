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
 .HasDefaultValue(true); // Changing the bool default value from false to true
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
# Methods
## Native Queries
`FromSqlRaw(string, params object[] parameters)` – изпълнява raw SQL заявки и поддържа параметри за защита от SQL инжекции. Винаги връща entity types.

`FromSqlInterpolated(FormattableString sql)` – позволява SQL интерполация, като автоматично параметризира стойностите.
## Change Tracking
`SaveChanges()` - прилага всички проследени промени върху базата данни, като генерира и изпълнява съответните SQL команди в рамките на транзакция.

`AsNoTracking()` - извлича данни от базата без да ги проследява Entity Tracker, което подобрява производителността при заявки, които не изискват модификация на обектите.

`Attach()` - закача обекта към контекста без да маркира нито едно свойство като променено. Можете по-късно да посочим целия обект или дадени свойства да бъдат маркирани като променени.

`Update()` -  закача обекта и маркира всички свойства като променени, което означава, че всяко свойство ще бъде актуализирано в базата данни, когато се извика `SaveChanges()`.
## JSON
### `System.Text.Json`
`JsonSerializer.Serialize(object, options)` - преобразува обект в JSON стринг. Използва се за сериализация на обекти в JSON формат, като поддържа опции за конфигуриране на процеса (например индентиране или игнориране на пропъртита).

`JsonSerializer.Deserialize<T>(jsonString, options)` - преобразува JSON стринг в обект от тип `T`. Извършва десериализация на JSON стринг обратно в обект, като мапира данните към зададения клас или структура.

`JsonSerializerOptions` - клас, който позволява конфигуриране на процеса на сериализация и десериализация. Например, може да се използва за задаване на правила за форматиране на дата, игнориране на пропъртита или дефиниране на специфични поведение при сериализация и десериализация на обекти.

Пример:

```csharp
var options = new JsonSerializerOptions { WriteIndented = true };
string jsonString = JsonSerializer.Serialize(person, options);
var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
```
### `JSON.NET`
`JsonConvert.SerializeObject(object)` - сериализира обект в JSON стринг, като поддържа множество опции за конфигуриране на сериализацията, като форматиране и контрол на пропъртитата.

`JsonConvert.DeserializeObject<T>(jsonString)` - десериализира JSON стринг в обект от тип `T`, като се грижи за правилното преобразуване на данните към съответния тип.
## XML Element Access
`SetElementValue(string name, string value)` – задава стойност на елемент с дадено име. Ако елементът не съществува, ще бъде добавен; ако стойността е `null`, елементът ще бъде премахнат:

```csharp
customer.SetElementValue("birth-date", "1990-10-04T00:00:00");
```

`Element(string name)` – извлича елемент по име. Ако елементът не съществува, връща `null`:

```csharp
var model = car.Element("model").Value;
```

`Remove()` – премахва елемент от родителския елемент:

```csharp
var youngDriver = customer.Element("is-young-driver");
youngDriver.Remove();
```

`SetAttributeValue(string name, string value)` – задава стойност на атрибут с дадено име. Ако атрибутът не съществува, ще бъде добавен; ако стойността е `null`, атрибутът ще бъде премахнат:

```csharp
customer.SetAttributeValue("name", "New Name");

// Alternatively
customer.Attribute("name").Value = "New Name";
```

`Attribute(string name)` – извлича атрибут по име. Ако атрибутът не съществува, връща `null`:

```csharp
customer.Attribute("name").Value
```

`Attributes()` – връща колекция от всички атрибути на елемента:

```csharp
var attrs = customer.Attributes();
```
## Misc
`ToQueryString()` - извлича SQL заявката, която ще бъде изпълнена в базата, когато използваме `IQueryable`.

`ExecuteDeleteAsync()` - извършва изтриване на записи от базата данни по дадено условие, като оптимизира производителността при масови изтривания. Поддържа асинхронни операции. Работи от EF8.

`ExecuteUpdateAsync()` - извършва обновяване на записи в базата данни по дадено условие, като оптимизира производителността при масови обновявания. Поддържа асинхронни операции. Работи от EF8.
# Bookmarks
[Entity Properties - EF Core | Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt) - Configuration Options for Entity Properties using Data Annotations or Fluent API.