# General
## Code First
Миграциите, представляват еволюцията на базата данни и са механизъм, който се използва само при Code First подхода. Постепенно променяме базата, като всяка промяна може да се окаже неподходяща и да се наложи да върнем промените обратно, ако е възможно, особено в етапа на разработка, например, когато клиентът промени изискванията. В момента, в който приложението е в продукция, това е доста рисково.

Еволюцията обикновено върви в посока на развитие, като добавяме нови данни, защото всяко връщане назад може да доведе до загуба на информация. Целта на миграциите е да се минимизират възможните загуби и да се предоставят предупреждения, когато има опасност от загуба на данни.

В обобщение, миграциите са безопасен инструмент за еволюиране на базата данни, който ни позволява да контролираме версиите. В миналото, подобни инструменти са били много скъпи, докато сега можем да ги използваме безплатно, и то с по-добри възможности.
## Database First
При Database First използваме scaffold, който ни позволява да генерираме моделите на базата данни в кода. Еволюцията на модела може да се извършва чрез последователно scaffold-ване и прилагане на необходимите промени. Важно е да се има предвид, че този процес не е част от механизма на миграциите, което води до загуба на проследимост и възможност за връщане назад, освен ако промените не се направят директно в базата данни.
Ако вече имаме база данни и трябва да се съобразим с нея, можем да използваме scaffold, за да създадем DbContext. Препоръчително е след това да създадем initial migration, в която закоментираме всичко в метода `Up()`, пускаме миграцията, за да бъде приложена върху базата данни (дори ако е празна). Така ще се създаде таблицата `__EFMigrationsHistory`, в която ще бъде записана initial migration, но тя няма да бъде приложена върху базата. След това, можем безопасно да продължим да работим с Code First.
Когато искаме да създадем копие на базата някъде другаде, променяме Connection String-а, използваме Update-Database и базата ще бъде изградена с всички направени миграции. Не трябва да забравяме да разкоментираме `Up()` метода, тъй като вече сме изпълнили миграцията, от която сме създали копието.
## How do Migrations Function
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250304202404.png)

Моделите се променят, когато добавяме нови features или правим други промени, които водят до промяна на базата данни. Това включва добавяне или премахване на нови ентитети и пропъртита.

За да може тези промени да се отразят в модела Code First, имаме нужда от нещо, което да приложи направените промени в кода към самата база данни, в нейната схема. Именно EF Migration е инструментът, който ни позволява да променяме схемата на базата данни, като същевременно поддържа синхрон между релационния и обектно ориентирания модел.

Много от default настройките в EF са направени така, че да не водят до унищожителни промени на базата данни. Системата се старае миграцията да бъде максимално щадяща към данните и да предотврати загубата им. Въпреки това, това не е винаги възможно на 100%, тъй като може да се наложи да премахваме таблици или пропъртита. Въпреки това, EF ни защитава колкото може и ни предупреждава, ако има риск от загуба на данни.
### Model Snapshot
Model Snapshot файла се появява само когато бъде направена първата миграция. Идеята му е да отразява състоянието на базата към текущата миграция. По този файл, EF се ориентира какви са разликите в миграциите. Когато към базата данни е приложена последната налична миграция, схемата на базата трябва да съответства на състоянието, описано в Model Snapshot файла.

Последователност на действията, когато изпълним миграция:
- EF сравнява текущия модел с `Model Snapshot` (който отразява последната приложена миграция).
- Генерира се миграционен файл, в който:
    - `Up()` съдържа само разликите (напр. нови таблици, нови колони, промени в типовете и т.н.).
    - `Down()` съдържа инструкциите за връщане на тези промени назад.
- Актуализира се `Model Snapshot`, за да съответства на последното състояние на модела.
- `Update-Database` изпълнява само `Up()` метода на новата миграция, без да изпълнява предишни `Up()` методи.
- EF вече знае как изглежда базата от предходните миграции и прилага само новите промени.
### Migrations Source Files
Те биват проследявани през source control. Принципно веднъж като се генерират, не се променят, освен ако не решим да направим персонализирани промени в нея.

Веднъж след като имаме създаден миграционния файл, тези промени могат да бъдат отразени в базата данни по няколко начина.
- Можем да използваме EF Core Tools, който прилага миграциите върху базата, като се свързва с нея чрез Connection String-а. EF Core Tools превръща миграционните файлове в SQL заявки и ги изпълнява върху базата. Този вариант е удобен, когато работим през Visual Studio или сме в процес на разработка и прилагаме миграциите, за да можем да тестваме.
- Друг вариант е да генерираме SQL скрипт, който след това ръчно да изпълним върху базата. Това обикновено се използва в среди с автоматизирано разгръщане (Continuous Integration/Continuous Deployment – CI/CD). В този случай се използват генерираните миграции от EF, които инструментът за автоматично разгръщане (без значение кой е той) копира върху сървъра на базата и изпълнява локално. Така миграциите се прилагат върху продукционната база, до която обикновено нямаме директен достъп.
## `EntityFrameworkCore.Tools`
Разпространява се като .NET tool. Microsoft предоставя инструменти, които могат да бъдат извиквани чрез команден ред с .NET и съответния инструмент, който ни е необходим. Другият вариант е да използваме вградената в Visual Studio Package Management Console (PMC). За да я използваме, трябва да инсталираме NuGet пакета **`EntityFrameworkCore.Tools`**.
## Create Migration
За да създадем миграция, трябва да изпълним командата:

CLI
```powershell
dotnet ef migrations add <MigrationName>
```

PMC
```powershell
Add-Migration <MigrationName>
```

Където `<MigrationName>` е името, което ще дадем на миграцията (например: `InitialCreate`, `AddColumnToTable` и т.н.).

След като създадем миграцията, тя бива приложена единствено към Model Snapshot файла, не към базата данни. Всяка миграция генерира Migration Class File, като първата миграция генерира и Model Snapshot file, който всяка следваща миграция обновява.
## Applying Migrations
За да приложим миграциите към базата данни, трябва да изпълним командата:

CLI
```powershell
dotnet ef database update <MigrationName>
```

PMC
```powershell
Update-Database <MigrationName>
```

Тези команди ще приложат посочената миграция към базата данни, а ако не се посочи име на миграцията, ще бъдат приложени всички pending миграции, което ще гарантира, че схемата на базата данни съвпада с текущото състояние на EF Core модела. EF Core проследява кои миграции са приложени чрез таблицата `__EFMigrationsHistory`. Важно е да се отбележи, че EF Tools се нуждае от достъп до базата данни, за да провери кои миграции вече са приложени и да генерира скрипт само за тези миграции, които все още не са били приложени. Когато няма достъп до базата, EF Tools разчита на CI/CD системата, която има достъп до базата, да извърши тази проверка и да генерира SQL скрипт от последната приложена миграция нататък, за да го изпълни на сървъра.

Ако базата данни не съществува, EF Core първо ще я създаде, след което ще добави таблицата `__EFMigrationsHistory`. След това ще изпълни `Up()` метода на миграцията и ще я запише в history таблицата, за да отбележи, че е приложена.
Това важи само когато използваме `update-database` или `dotnet ef database update`. Ако вместо това използваме `EnsureCreated()`, базата ще бъде създадена без да се прилагат миграции и без `__EFMigrationsHistory`.

Процеса се развива в няколко стъпки:
- Проверява се Migration History, като се сравняват приложените миграции записани в таблицата `__EFMigrationsHistory` с наличните миграции, сортирани по timestamp-a.
- Генерира се SQL скрипт, който е базиран на `Up()` методите на pending миграциите.
- Генерирания скрипт се стартира и обновява схемата на базата данни.
- След успешното обновление на схемата, се прави запис в `__EFMigrationsHistory`, където се вкарва името на миграцията и версията на EF Core с която е била създадена, за да не бъде изпълнена още веднъж.
### Listing All Migrations
Можем да видим всички налични миграции, като изпълним командата:

CLI
```powershell
dotnet ef migrations list
```

PMC
```powershell
Get-Migration
```

В колоната `Applied` ще видим дали дадена миграция е приложена към базата данни. За да определи дали миграцията е приложена или не, EF Core трябва да се свърже с базата данни чрез connection string-а. Когато изпълним командата, EF Core ще провери таблицата `__EFMigrationsHistory` на съответната база, за да види дали миграцията е била приложена или не. Може да имаме много бази и те да са в различни стадии на еволюцията си - на едната да са приложени две миграции, на другата три, на третата нищо или всички и тн. Всяка база си е сама за себе си, поради което и `__EFMigrationsHistory` таблицата е вътре в базата и тя пази информацията за съответната база, до къде е стигнала нейната еволюция.

Можем да видим всички налични миграции, като изпълним командата:
## Evolving the Model
Миграциите се съхраняват в папката `Migrations` на главния проект. В тях се намират:

- Методът `Up()` – съдържа промените спрямо snapshot файла, които ще бъдат приложени към базата данни.
- Методът `Down()` – дефинира действията за връщане на тези промени, ако се наложи премахване на миграцията.
### Removing a Migration
След като добавим промени в модела и създадем миграция, но впоследствие решим да направим корекции или допълнителни изменения, можем да изтрием миграцията, ако тя още не е приложена към базата данни и да я създадем отново след направените промени. Ако имаме повече от една не приложени миграции, може да ги премахваме една по една.

Изтриването става с командата:

CLI
```powershell
dotnet ef migrations remove
```

PMC
```powershell
Remove-Migration
```

След като изтрием миграция, нейният файл бива премахнат от папката `Migrations`. Също така, при изтриване на миграцията, snapshot файлът се възстановява към състоянието на предишната миграция. Snapshot файлът се моделира въз основа на наличните миграции. Дори ако сме променили модела, ако не създадем нова миграция, тези промени няма да бъдат отразени в snapshot файла.

Ако миграцията която искаме да изтрием е приложена към базата данни, за да я изтрием трябва да приложим предишната преди нея миграция към базата данни и след това ще може да я изтрием. Това става чрез командата за update, като посочим и името на предишната миграция.

Ако миграцията, която искаме да изтрием, вече е приложена към базата данни, първо трябва да върнем базата към предишната миграция, преди да я изтрием. Това става с командата:

CLI
```powershell
dotnet ef database update <PreviousMigrationName>
```

PMC
```powershell
Update-Database <PreviousMigrationName>
```

Когато използваме командата за обновяване на базата до посочената предишна миграция, EF Core ще изпълни `Down()` методите в обратен ред на всички миграции, които са били приложени след нея. Така базата ще бъде в състоянието на посочената миграция и ще може да изтрием нежеланата миграция. Ако не я изтрием, миграцията ще продължи да съществува в проекта, но вече няма да е приложена към базата данни.

> [!WARNING]  
> EF Core проследява миграциите, които са приложени към базата данни, като използва текущия `Connection String`. Ако миграцията е била приложена в различна база (или към различна среда), не можем просто да я изтрием, без първо да я върнем назад (revert), защото няма да имаме достъп до метода `Down()` в тази база.
> 
> Затова, ако миграцията е приложена към повече от една база или среда, трябва да я "revert"-нем навсякъде, преди да можем да я изтрием. Това гарантира, че състоянието на всички бази ще бъде синхронизирано и няма да имаме несъответствия между тях.
### Resetting All Migrations
В някои екстремни случаи може да се наложи да изтрием всички миграции и да започнем отначало. Например, ако сме прецакали `model snapshot` файла или ако искаме да преминем към различен провайдър, който изисква различни миграции. Миграциите са генерирани със стария провайдър и могат да бъдат специфични за него.

В такъв случай трябва да изтрием цялата папка с миграциите, включително и файла на `model snapshot`. Ако не искаме да изтрием базата данни, можем да изпразним таблицата `__EFMigrationsHistory`. Това ще премахне информацията за приложените миграции от базата, като тя ще изглежда "чиста" от гледна точка на миграциите.

След това, когато създадем първата миграция, тя ще съдържа цялата схема, съответстваща на текущия модел. Това обаче означава, че ще изгубим историята на еволюцията на базата данни и няма да можем да се върнем към предишни миграции.
## Customize Migration Code
Рядко прибягваме до редактиране на миграции, тъй като има голям риск от непредвидени проблеми. Промените, които правим в миграциите, е добре да ги commit-нем в repository, защото ако създадем нова база данни, тези промени няма да бъдат налични. Възможността да редактираме миграциите в EF Core е мощен инструмент, но тя също така увеличава риска от сериозни проблеми, ако не се използва внимателно.

Понякога default миграциите не отговарят на специфични бизнес изисквания, поради което може да се наложи да ги customize-нем.

Customize-ването на миграции осигурява по-прецизен контрол върху промените в схемата на базата данни. Например, може да избегнем пълното изтриване на данни, въпреки че моделът вече не ги съдържа и не работи с тях. EF Core е много гъвкав в това отношение и никога не прави заявка `SELECT *`. Вместо това, той изрежда само колоните, които трябва да селектира. Това ни дава възможност, ако искаме да премахнем определени елементи от модела, без да губим информация, да премахнем пропъртитата от модела, да направим миграцията със закоментирано изтриване на тези колони отговарящи на пропъртитата и да я приложим към базата данни. Колоните ще си останат в базата данни, но няма да бъдат достъпни за приложението, защото EF ще изброява само колоните, които съществуват в текущия модел. Това означава, че физически колони ще останат в базата данни, но те няма да се използват от приложението.

В някои случаи, customize-ването на миграции може да е необходима и при сложни трансформации на данни, за да осигурим целостта на данните по време на промените в схемата.
### How to Customize
След създаването на миграция, тя генерира два метода - `Up()` и `Down()`. Методът `Up()` се изпълнява, когато прилагаме миграцията върху базата, а методът `Down()` се изпълнява, когато премахваме миграцията от базата и възстановяваме направените промени.

Можем да модифицираме тези методи според нуждите на проекта. Един пример за такава модификация е, когато променяме името на дадено пропърти. Проблемът тук е, че EF Core сравнява модела с snapshot file-а, но не може да разбере дали даденото пропърти е преименувано или изтрито и създадено наново. И в двата случая, резултатът в нашия модел е същият, но EF Core не може да определи дали това е преименуване или изтриване. По-често срещаното действие е да изтрием и добавим ново пропърти, отколкото да променяме името на съществуващо пропърти. Поради това, когато EF Core не може да разпознае промените, той приема, че колоната е изтрита и добавена наново. Това обаче води до загуба на данни от изтритата колона. Понякога EF Core успява да разпознае, че дадена колона е била преименувана, но не трябва да разчитаме на това поведение. Всички подобни ситуации е добре да се обработват чрез ръчни модификации на миграционните файлове, за да се гарантира, че данните няма да бъдат загубени.
## Connection String
Използва се за настройка на връзката към базата данни, като тези настройки се подават към framework-а чрез connection string-а. Трябва да се има предвид, че той е provider-specific (зависим от типа на базата данни), информацията тук е специфични за SQL Server.

В най-простия си вид изглежда така:

**Standard Security:**

```
Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
```

Ако сървърът използва истински сертификат, не е нужно да добавяме `TrustServerCertificate=true`, тъй като сертификатът ще бъде проверен автоматично. Но ако използваме тестови сертификат, трябва изрично да посочим, че искаме да му се доверим, като добавим `TrustServerCertificate=true`.
### Components
**Server** - Името или адресът на SQL Server инстанцията. Ако работим с конкретна инстанция, трябва да посочим нейното име, тъй като SQL Server може да работи с няколко сървъра на една и съща машина (същият application server може да хоства множество DB сървъри).

**Database** - Името на базата данни към която искаме да се свържем.

**Authentication Details** - Потребителски данни за достъп до базата. Те могат да бъдат в различни формати, например Windows Credentials (`Trusted_Connection=True`), което означава, че се използва акаунтът, с който сме влезли в операционната система. Когато използваме Windows Credentials, няма да работи при свързване към отдалечена машина, тъй като както приложението, така и SQL Server-а трябва да се намират на една и съща машина. SQL Server поддържа и други методи за удостоверяване - с потребителско име и парола и други.

**Other Settings** - Има много други възможности за конфигуриране, като например: timeouts, pooling, конфигурации за достъп до чувствителни данни в логовете и други. Тези настройки са provider-specific, така че трябва да се запознаем с тях в документацията на съответния provider.
### Configuring
Connection string-а може да бъде конфигуриран в метода `OnConfiguring()` на класа `DbContext`. Въпреки това, този подход не се препоръчва.

По-добре е да се използва configuration framework и dependency injection (DI) за конфигуриране на връзката към базата данни, защото това позволява по-добро разделяне на отговорностите и по-лесно управление на настройките в различни среди (например за локално разработване, тестове или продукция).
Този подход с DI и конфигурация през framework-a е предпочитан, защото осигурява централизирано управление на настройките и улеснява промените в различни среда без необходимост от кодови промени.
# Misc
# ChatGPT
## `EnsureCreated()` & `EnsureDeleted()` for Bypassing Migrations
1. **`EnsureDeleted()` + `EnsureCreated()`**
    
    - **Deletes** the existing database and **creates** a new one from scratch.
    - **All data is lost** every time it's run.
    - Bypasses **migrations** completely.
    - Useful for **development/testing**, but **not for production**.
2. **`EnsureCreated()` (without `EnsureDeleted()`)**
    
    - **Creates** the database **only if it doesn’t exist**.
    - **Does NOT update the schema** if changes (new columns/tables) are made.
    - Cannot be used alongside **migrations**—it’s a one-time setup method.
3. **Migrations (`Add-Migration` & `Update-Database`)**
    
    - Applies **incremental changes** to the database schema.
    - **Preserves data** and updates only what’s necessary.
    - Recommended for **production-ready applications**.

✅ Best Practice:

- Use **`EnsureDeleted()` + `EnsureCreated()`** only in **temporary/testing scenarios**.
- Use **migrations** for handling schema changes **without losing data**.
## Up() and Down() Methods
Each migration in EF Core consists of two methods:

- **`Up()`** → Applies the migration (adds changes to the database).
- **`Down()`** → Reverts the migration (removes the changes).

When applying migrations, EF executes the `Up()` methods in sequence. If rolling back to a previous migration, EF executes `Down()` for all newer migrations in reverse order.

**Example 1: Basic Migration Flow**

Suppose we have the following migrations:

1. **Migration1** (adds `Products` table)
2. **Migration2** (adds `StockQuantity` column to `Products`)
3. **Migration3** (removes `StockQuantity`)

**Applying Migrations (`Up()`)**

Running `dotnet ef database update` applies migrations in order:

- `Up()` from **Migration1** → Creates the `Products` table.
- `Up()` from **Migration2** → Adds the `StockQuantity` column.
- `Up()` from **Migration3** → Removes the `StockQuantity` column.

**Rolling Back to Migration1 (`Down()`)**

Running `dotnet ef database update Migration1`:

- `Down()` from **Migration3** → Restores `StockQuantity`.
- `Down()` from **Migration2** → Removes `StockQuantity`.

The `Products` table remains because **Migration1** is still applied.

**Example 2: Adding and Removing a Column**

**Migration1: Creating a Table**

```csharp
public partial class Migration1 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(nullable: false),
                Price = table.Column<decimal>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Products");
    }
}
```

**Migration2: Adding a Column**

```csharp
public partial class Migration2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "StockQuantity",
            table: "Products",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "StockQuantity", table: "Products");
    }
}
```

**Migration3: Removing the Column**

```csharp
public partial class Migration3 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "StockQuantity", table: "Products");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "StockQuantity",
            table: "Products",
            nullable: false,
            defaultValue: 0);
    }
}
```

**Example 3: Rolling Back Changes**

If you're currently on **Migration3** and run:

```
dotnet ef database update Migration1
```

EF Core will:

1. **Execute `Down()` from Migration3** → Restores `StockQuantity`.
2. **Execute `Down()` from Migration2** → Removes `StockQuantity`.

After this, only **Migration1** remains applied, meaning the `Products` table still exists, but the `StockQuantity` column is gone.
## Snapshot File and Migrations
The snapshot file reflects the state of the **last created migration**, regardless of whether it has been applied to the database or not. It gets updated each time a new migration is added. If a migration is deleted, the snapshot will revert to the previous migration's state, even if the deleted migration was never applied.
## Migration and Designer Files in EF Core
In Entity Framework (EF) Core, when you create a migration, it generates two files for each migration:

1. **The Migration File (e.g., `20230302120000_AddEmailToPerson.cs`)**: This file contains the migration logic, including the `Up()` and `Down()` methods, which describe the changes to be applied to the database schema (e.g., adding/removing columns or tables).

2. **The Designer File (e.g., `20230302120000_AddEmailToPerson.Designer.cs`)**: This file is automatically generated by EF Core and contains metadata about the migration. It includes the migration's name, a snapshot of the model state at the time of the migration, and other information that EF Core needs to manage and apply migrations correctly. This file is not intended to be manually edited.

The **Designer file** serves as a way for EF Core to track changes between migrations, and it's automatically updated when you add, remove, or update a migration. You won't usually interact with this file directly, as it’s part of the internal workings of EF Core.

**Why do you have both files?**

- **Migration file**: Contains the logic for schema changes.
- **Designer file**: Contains metadata and is required for EF Core's internal migration management.

Both files work together to ensure EF Core can correctly apply and track migrations. The Designer file helps EF Core understand what changes were made in the migration, even if the schema changes are rolled back or re-applied.
# Bookmarks
Completion: 06.03.2025