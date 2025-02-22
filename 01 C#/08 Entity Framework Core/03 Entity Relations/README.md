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
    public Passport? Passport { get; set; } // Nullable → One-to-One or Zero
}

public class Passport
{
    public int Id { get; set; }
    public string Number { get; set; }

    public int PersonId { get; set; }  // Foreign Key to Person
    public Person Person { get; set; } 
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
Code First – когато пишем код, на базата на който Entity Framework генерира база данни, нашите POCO (Plain Old CLR Objects) класове се мапват към таблици. За да се случи това, информацията за нашите класове не е достатъчна, трябва мета информация, която да предостави нужната информация, за създаването на базата данни. Тази мета информация идва няколко места:
- Fluent API
- Data Annotations
- Набор от конвенции

Майкрософт, се опитват да наложат подхода **Convention over Configuration** с идеята да си спестим работа, като не описваме очевидните неща. Целия ASP.NET Core е изграден върху тази концепция. В голям процент от случаите, конвенциите вършат много добра работа, като не трябва да описваме нищо, след като сме създали класовете, няма нужда от мета информация. Проблема е че не са гъвкави и поради това имаме оставена възможността за конфигурация. Чрез Fluent API / data annotations, имаме инструмент с който да override-ваме конвенциите. Fluent API е с най-висок приоритет, след това е data annotations и с най-нисък приоритет са конвенциите.

Чрез Fluent API / data annotations може да накараме EF експлицитно да извършва дадени действия, като това е препоръчителният вариант.

По конвенция, пропърти с име `Id`  както и `<ClassName>Id` (например, `PersonId` за клас `Person`)`се мапва като Primary Key. 

Fluent API (Model Builder) позволява пълен контрол над DB мапингите:
- Може да наименуваме всички обекти, без значение дали са колони, таблици, sequences и тн.
- Валидации и типове данни. Валидациите, направени чрез Fluent API, ще работят винаги в базата данни, докато валидациите, направени чрез data annotations, могат да не бъдат приложени към базата данни, в зависимост от типа на валидацията. Например, валидации за дължина или диапазон на стойности, направени чрез data annotations, могат да не се прехвърлят директно в SQL скриптовете на базата данни.
- Дефиниране на сложни връзки между обектите.
### Working with Fluent API
Mапингите се извършват в метода `OnModelCreating()`, който е част от класа `DbContext`. Трябва да го override-нем и вътре в него, като използваме `ModelBuilder`, да конфигурираме базата данни. EF автоматично предоставя `ModelBuilder` като аргумент на метода. Това се случва вътрешно, когато EF инициализира `DbContext`. При стартиране на приложението EF създава инстанция на `DbContext` и извиква `OnModelCreating()`, като подава `ModelBuilder`, който съдържа API за конфигуриране на моделите.
#### Mappings
Списък с mappings и начина им на работа има във файла за EF Core в папката с ресурси.
#### Specialized Configuration Classes
В Fluent API съществуват конфигурации, които могат да се прилагат на ниво цялата база данни и такива, които се отнасят само за конкретни таблици. Например, глобалните филтри са валидни за всички записи в базата и обикновено се задават директно в класа `DbContext`.

Когато конфигурираме отделни таблици, е добра практика да изнесем тези настройки в самостоятелни класове, които имплементират интерфейса `IEntityTypeConfiguration<TEntity>`. Обособяването на конфигурационните класове в отделна папка подобрява структурата и четимостта на проекта.

Примерна конфигурация за `Student`:

```csharp
public class StudentConfiguration
   : IEntityTypeConfiguration<Student> // Specify target model
{
   public void Configure(EntityTypeBuilder<Student> builder)
   {
       builder.HasKey(s => s.StudentKey);
   }
}

// Include in OnModelCreating

public class StudentDbContext : DbContext
{
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.ApplyConfiguration(new StudentConfiguration());
   }
}
```

**Обяснение:**

- Класът `StudentConfiguration` имплементира `IEntityTypeConfiguration<Student>`, което позволява конфигурирането на `Student` модела.
- Методът `Configure(EntityTypeBuilder<Student> builder)` получава `builder`, чрез който се задават настройките за съответната таблица.
- В случая определяме `StudentKey` като първичен ключ чрез `HasKey()`.
- В `OnModelCreating()` метода на `DbContext` класа, трябва да използваме `modelBuilder`, за да прилагаме конфигурациите, и по-конкретно методът `ApplyConfiguration`, за да добавим конфигурацията от `StudentConfiguration`.

**Предимства на този подход**

**По-структуриран код** – Конфигурациите се организират поотделно, вместо да се струпват в `OnModelCreating()`.  
**По-добра поддръжка** – В големи проекти `OnModelCreating()` може да достигне хиляди редове код, което го прави трудно четим и поддържан.  
**По-ясна отговорност** – Всяка конфигурация се отнася само за едно ентити, което подобрява разграничението на логиката.

**Заключение:**  

Използването на `IEntityTypeConfiguration<TEntity>` е добър подход за управление на **конкретни таблици**, докато глобалните настройки (като филтри) е препоръчително да останат в `DbContext`.
## Attributes
EF Code First ни предоставя набор от `DataAnnotation` атрибути, чрез които до голяма степен можем да извършваме конфигурации, които иначе бихме направили чрез Fluent API. Това обаче остава необходимо, когато искаме да приложим всички възможни конфигурации. Ако има конфликт между конфигурация направена чрез Fluent API и атрибутите, Fluent API има по-голям приоритет и неговите настройки, ще бъдат приложени.

Трябва да ползваме следните using-и:

- Access nullability and size of fields - `using System.ComponentModel.DataAnnotations`
- Access schema customizations - `using System.ComponentModel.DataAnnotations.Schema`
### Mappings
Списък с mappings и начина им на работа има във файла за EF Core в папката с ресурси.
## Migrations
След като сме описали конфигурацията на базата данни в `OnModelCreating()`, трябва да направим миграция, за да създадем съответните таблици в базата.
Миграциите представляват source control, кога какво сме променяли и можем да revert-нем към предишни версии, ако решим. Трябва да се внимава, защото ако revert-нем към предна версия и премахнем нещо в което вече има данни, ще ги загубим. 

Ако искаме да премахнем конкретна миграция в EF, трябва да актуализираме базата данни до миграцията, която е преди нея. Това ще доведе до загуба на всички промени, направени от миграцията, която премахваме, включително промени в данни и схеми. Това ще върне базата данни в състоянието, което е било след изпълнението на посочената миграция, като всички по-късни миграции ще бъдат отменени.

Пример: Ако имаме 10 миграции и искаме да се върнем до миграция 2, всички миграции от 3 до 10 ще бъдат отменени, тъй като не можем да премахнем една миграция, без да премахнем и всички след нея. Това се дължи на зависимостта между миграциите – те са последователни и не можем да премахнем една миграция без да отменим и всички следващи, които зависят от нея. Така че, ако искаме да изтрием миграция 3, трябва да върнем базата до миграция 2 и след това да премахнем миграции 4, 5, ..., 10 и след това да създадем нова миграция, ако е необходимо. Това означава, че не можем директно да изтрием миграция 3, без да изтрием миграции 4 до 10 първо. Можем да изтрием всички миграции след миграция 2, а след това да добавим нова миграция, ако е необходимо.

Ако се върнем към миграция 2 и създадем нова миграция, без да изтрием миграции от 3-10, ще се получи разклонение в последователността от миграции, тъй като ще имаме две отделни линии на миграции:

- **Линия 1**: Миграции 1, 2, новата миграция и всички последващи миграции.
- **Линия 2**: Миграции 3-10, които остават в кода, но не се прилагат към базата данни след връщането към миграция 2.

Ако не се иска разклонение, миграциите 3-10 трябва да бъдат изтрити, след което се създава нова миграция. Това ще осигури последователна линия на миграции, като базата данни ще премине през миграции 1, 2 и новата миграция.


**В PowerShell (.NET CLI, извън Visual Studio)**

```powershell
dotnet ef migrations add MigrationName --context ApplicationDbContext && dotnet ef database update --context ApplicationDbContext
```

**В Package Manager Console (PMC) (Visual Studio)**

```powershell
`add-migration MigrationName -Context ApplicationDbContext; update-database -Context ApplicationDbContext`
```

**Обяснение:**

`Context ApplicationDbContext` се използва, когато имаме повече от един DbContext в проекта, за да уточним върху кой контекст да се извършват миграциите.

`MigrationName` трябва да бъде заменено с ясно, описателно име на миграцията, което обяснява направените промени (например `AddStudentTable` или `UpdateStudentSchema`).

Командата `update-database` прилага всички неизпълнени миграции върху базата данни, което означава, че тя актуализира схемата на базата данни според промените, описани в миграциите.

**Допълнителни команди:**

Списък с всички миграции: В случай на проблеми с миграциите, може да ползваме командата **`dotnet ef migrations list`** или **`Get-Migrations`** в PMC, за да видим списък с всички миграции:

**.NET CLI:**

```powershell
dotnet ef migrations list --context ApplicationDbContext
```

**PMC (Visual Studio):**

```powershell
Get-Migrations -Context ApplicationDbContext
```

**Премахване на последната миграция**: Ако миграцията не е приложена към базата данни, може да я премахнем с командата **`remove`**:

**.NET CLI:**

```powershell
dotnet ef migrations remove --context ApplicationDbContext
```

**PMC (Visual Studio):**

```powershell
Remove-Migration -Context ApplicationDbContext
```

Тази команда премахва последната миграция от проекта. Ако миграцията е вече приложена към базата данни, трябва първо да я отменим, чрез командата:

**.NET CLI:**

```powershell
dotnet ef database update <previous_migration> --context ApplicationDbContext
```

**PMC (Visual Studio):**

```powershell
update-database <previous_migration> -Context ApplicationDbContext
```
### Model Snapshot File
Model Snapshot е файл, който се намира в папката `Migrations`, заедно с миграциите и много прилича на Fluent API. Той съдържа информация за структурата на базата данни в момента, когато е създадена миграцията, включително всички промени, които може да са направени в модела (като добавяне или премахване на таблици, колони, индекси и т.н.). 
Това е начинът, по който EF може да следи промените в базата данни, без да се нуждае от повторно генериране на база от нулата. Всяка миграция, която създава нови промени в базата данни, се отразява в snapshot файла. Този файл е част от проекта и представлява текущото състояние на модела на базата данни, като включва всички променени или добавени таблици, колони, индекси и други елементи.

При всяка нова миграция, Entity Framework обновява този файл, за да отрази актуалното състояние на базата данни, което е дефинирано в моделите. Това позволява на Entity Framework да изчисли разликите между текущото състояние на базата данни и новата миграция, за да генерира необходимите SQL скриптове.
## Table Relationships
При всички релации в EF Core е важно как структурираме класовете:

- Ако не посочим експлицитно Foreign Key (FK), EF Core ще го добави автоматично, като следва конвенциите.
- Ако изрично добавим Foreign Key (например `DepartmentId` в `Employee`), EF Core ще го приеме като външен ключ и няма да създава автоматично друг.
- Когато експлицитно указваме FK, трябва да използваме `[ForeignKey]` атрибут или Fluent API, ако искаме допълнителна конфигурация.

Дори без атрибути или Fluent API, EF Core ще разпознае Foreign Key, ако класовете са правилно структурирани, като следва конвенциите.

В EF конвенцията е, че външният ключ (Foreign Key) се поставя в таблицата от страната на "много" в релацията "едно към много" (one-to-many).
ако погледнем от страна на обектите в C#, тогава външният ключ винаги се намира в класа, който съдържа референция (единичен обект), а не колекция.
### One-to-Zero-or-One
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
### One-to-Many
Това е най-често използваната релация.

Имплементира се чрез създаване на колекция в родителската таблица, като не трябва да забравяме да я инициализираме.

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
### Many-to-Many
Когато създаваме релация „много към много“ в базата данни, е необходимо да добавим междинна (mapping) таблица. В EF Core това може да се реализира по два начина:
#### Explicit Join Table
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
#### Implicit Join Table
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
### Multiple Relations
Когато две ентитита са свързани с повече от един Foreign Key, например, когато имаме класовете `Person` и `Town`, в класа `Person` може да имаме две пропъртита като `PlaceOfBirth` и `CurrentResidence`. В класа `Town`, от своя страна, ще имаме две колекции, които отразяват тези връзки. В такъв случай, EF Core може да се затрудни да определи коя колекция отговаря на кой Foreign Key, тъй като и двете колекции съдържат елементи от тип `Person`. За да помогнем на EF Core да установи коректните навигационни връзки, използваме атрибута `[InverseProperty("RelatedPropertyName")]`. Важно е да отбележим, че не можем да използваме `nameof()`, тъй като атрибутът се прилага за свойства от друг клас и трябва да посочим името на съответното навигационно пропърти като `string`.

```csharp
public class Person
{
	 public int Id { get; set; }
	 public string Name { get; set; }

	 public int PlaceOfBirthTownId { get; set; }
	 public int CurrentResidenceTownId { get; set; }
	 public Town PlaceOfBirth { get; set; }
	 public Town CurrentResidence { get; set; }
}

public class Town
{
	 public int Id { get; set; }
	 public string Name { get; set; }

	 [InverseProperty("PlaceOfBirth")] // Points toward related property
	 public ICollection<Person> Natives { get; set; }

	 [InverseProperty("CurrentResidence")]
	 public ICollection<Person> Residents { get; set; }
}
```
# Misc
## `ModelBuilder` Class
Този клас както и всички builder класове, позволяват да конфигурираме обекта, който build-ваме. `ModelBuilder` класът е много полезен инструмент за конфигуриране на модели в EF Core, като предоставя много опции за конфигурация на базата данни. Той ни позволява да зададем точни настройки за нашите ентитита, да определяме правила за валидация и да изграждаме релации между таблиците в базата данни, използвайки Fluent API.
## Schemes
Схемата в базата данни може да се разглежда като "папка", в която се групират таблици и други обекти (например изгледи, функции, индекси и др.). Това дава възможност за логическо организиране на данни и управление на достъп до тях.

Основните предимства на схемите включват:

 **Групиране на обекти**: Таблици и други обекти могат да бъдат организирани в различни схеми за лесно управление и разделяне.

**Контрол върху достъпа**: Чрез схемите може да се контролира кой потребител има достъп до конкретни таблици или други обекти. Това означава, че различни потребители могат да имат различни нива на достъп върху таблици, базирани на схемата, към която принадлежат.

**По-добро управление на обекти**: Може да се използва схема за организиране на таблици по различни критерия, като например функционални области или различни групи потребители.

**Роля и права за достъп**: Чрез схемата може да се предоставят специфични права за достъп и контрол върху данни.

**Namespace**: Схемата служи и като namespace, което означава, че можем да имаме еднакви имена за таблици в различни схеми и да се обръщаме към тях чрез схемите.

Пример: Ако имаме схема `admin`, може да предоставим различни права на администраторите за таблиците в нея, докато друга схема като `user` може да съдържа таблици с ограничен достъп за редовни потребители.

Това е основната идея за схемите в релационни бази данни като SQL Server или PostgreSQL.
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
## Table Relations
When we think about SQL Server table relations for two tables, the right question to ask is how many times the primary key of the first table is referenced in the records of the second table and vice versa. If the primary key of the first table is referenced in more than one record in the second table, then the second table represents the "many" side. If the primary key of the second table is not found in the first table, then it represents the "one" side of the relation.

When we talk about a many-to-many relationship, this means we have two one-to-many relationships where the join table's composite key is not found in the other tables. However, the primary keys of the other two tables are referenced in multiple records in the join table, making it the "many" part.

**ChatGPT:**

Yes, you are on the right track! Let me clarify and refine your explanation a bit for better precision:

1. **One-to-Many (1:M) Relationship:**
    
    - If the primary key of the first table appears multiple times as a foreign key in the second table, then the second table represents the "many" side of the relationship.
    - Conversely, if the primary key of the second table is not referenced in the first table, then it represents the "one" side.
2. **Many-to-Many (M:M) Relationship:**
    
    - This type of relationship exists when both tables' primary keys appear multiple times in a third table (often called a **junction table** or **join table**).
    - The junction table contains foreign keys referencing the primary keys of the two related tables. Each of these foreign keys can appear multiple times, forming **two one-to-many (1:M) relationships** with the junction table.
    - The junction table itself does not contain primary keys of the other two tables as its own primary key. Instead, it typically has a **composite primary key** made up of the two foreign keys.

**Example:**

Consider **Students** and **Courses**:

- A student can enroll in multiple courses.
- A course can have multiple students.

To model this, we introduce a **StudentCourse** junction table:

- It contains `StudentID` (FK) and `CourseID` (FK), forming a **composite primary key** (`StudentID, CourseID`).
- Each `StudentID` can appear multiple times (for different courses).
- Each `CourseID` can appear multiple times (for different students).

This establishes two **one-to-many** relationships:

1. **Students (1) → (M) StudentCourse**
2. **Courses (1) → (M) StudentCourse**

Together, they create a **many-to-many (M:M) relationship** between Students and Courses.

So yes, your understanding is correct! The key idea is that a **many-to-many** relationship consists of **two one-to-many relationships** with a join table, where each of the original tables' primary keys appear multiple times in the join table.
# Bookmarks
[Entity Properties - EF Core | Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt) - full Configuration Options for Entity Properties using Data Annotations or Fluent API.
Completion: 19.02.2025