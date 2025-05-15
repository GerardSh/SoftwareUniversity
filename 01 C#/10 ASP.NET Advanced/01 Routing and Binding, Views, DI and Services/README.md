# General
## Model Binding
Мост между HTTP заявката и параметрите на action метода. В самата HTTP заявка има множество различни източници, откъдето могат да се подават данни – като route параметри, query string, form полета, headers и тн. 

Целта на байндърите е да извлекат тези данни и да ни ги предоставят в обработен и удобен за използване вид в C#.

Байндърът извлича наличните данни от заявката – например от query string, където данните са представени като двойки _име=стойност_, или от form data, където структурата също е на базата на име и стойност.

След това байндърът търси дали има параметри в action метода или пропъртита в по-сложен обект (като клас), които съвпадат по име с получените данни, и автоматично ги запълва.

При route параметрите процесът е малко по-специфичен – проверява се дали URL пътят на заявката съвпада с този, който е дефиниран в маршрута на контролера. Ако имената в route шаблона съвпадат с имената на параметрите в метода, тогава стойностите от пътя се мапват към тези параметри.

Данните от HTTP заявките се използват от контролерите.

Ако свързването не е успешно, не се хвърля грешка, но се записва error message.

Поведението на модела за свързване може да бъде персонализирано и да си направим собствени.

Основната идея на **model binder-а** в ASP.NET Core е да **вземе данни от HTTP заявката** (които винаги пристигат като **string-ове**) и да ги **преобразува в обекти или типове**, с които **да работим директно в нашия код**.

Работата на model binder-а е:

Взима стойности от различни източници на заявката (route, query string, form, body и т.н.)

Съпоставя имената на тези стойности с параметрите или пропъртитата, които очакваме

Конвертира string-овете към съответните типове – като `int`, `DateTime`, `bool`, обекти и други

Връща ни готов обект, който можем да ползваме веднага в контролера

Идеята на байндъра е да ни преобразува string-овете от заявката в смислени C# типове, с които можем да работим удобно.
### Attributes
Вграденото поведение на Model Binding може да бъде насочено към конкретен източник. Реално байндърът проверява няколко източника на данни в заявката и търси съвпадения по име между тях и параметрите на метода или пропъртитата в моделите.

По подразбиране той обхожда източници като route, query string, form data и headers, за да намери стойности, които съвпадат по име.

Можем обаче да ограничим този процес и да укажем изрично откъде да се извличат данните, като използваме атрибути.

Така избягваме неясноти и контролираме по-точно как да се обработва входът.

Фреймуъркът предоставя няколко атрибута за тази цел:

`[BindRequired]` – добавя грешка в `ModelState`, ако байндингът не може да се извърши.

`[BindNever]` – указва на байндъра никога да не свързва този параметър.

`[From{source}]` – използва се за указване на точния източник на данните: `[FromHeader]`,`[FromQuery]`, `[FromRoute]`, `[FromForm]`

`[FromServices]` – се използва за **Dependency Injection** (DI) и позволява на параметрите в метода да бъдат попълнени от регистрирани услуги в контейнера на DI. Данните за тези параметри не идват от HTTP заявката, а се предоставят от DI контейнера, който управлява зависимостите в приложението.

`[FromBody]` – използва конфигурираните formatters, за да байндне данни от тялото на заявката. Formatter-a се избира на база **Content-Type** header-а на заявката.

`[ModelBinder]` – използва се за презаписване на стандартния байндър, източника на данни и името на параметъра.

Пример:

Ако имаме параметър `id` в контролер и използваме `[FromRoute]`, тогава **само стойността от маршрута (URL пътя)** ще бъде използвана за байндинг.

Пример:

```csharp
[HttpGet("products/{id}")]
public IActionResult GetProduct([FromRoute] int id)
{
    // here id will come only from the URL path, e.g. /products/5
}
```

В този случай, дори ако в заявката има `id` в query string (`?id=5`) или в тялото (ако е POST), **то няма да бъде взето под внимание** – байндърът ще погледне **само в route параметрите**.

Това е полезно, защото така се избягват неясноти или конфликти, ако `id` се подава на повече от едно място. Използването на `[FromRoute]` (или друг конкретен атрибут) гарантира, че се гледа точно определения източник.
### Custom Model Binder
Персонализираното байндиране на модел може да бъде напълно настроено. То може да бъде добавено като глобален филтър, като така ще важи за всички, или да се добави с атрибут **model binder** там, където е необходимо.
Трябва да създадем `BindingProvider` и Binder:

```csharp
[ModelBinder(BinderType = typeof(StudentEntityBinder))]
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class StudentEntityBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        // TODO: Do Magic ...
        bindingContext.Result = ModelBindingResult.Success(model);
        return Task.CompletedTask;
    }
}

public class StudentEntityBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        if (context.Metadata.ModelType == typeof(Student))
        {
            return new BinderTypeModelBinder(typeof(StudentEntityBinder));
        }
        return null;
    }
}

services.AddControllerWithViews(options =>
{
    options.ModelBinderProviders
        .Insert(0, new StudentEntityBinderProvider());
    // Add custom binder to beginning
});
```
## Model Validation
Валидирането на модела се извършва след байндирането на модела.

Отчита грешки, които произлизат от процеса на байндинг.

Съществуват два вида валидация - сървърна и клиентска. Клиентската валидация повишава качеството на потребителското изживяване (UX), като предоставя по-бърза и интерактивна обратна връзка.

Свойството `ModelState.IsValid` показва дали валидацията на модела е успешна.

Обхожда се списъкът с грешки.
### Custom Model Validation
Атрибутите за валидация покриват повечето нужди, но не всички.

Понякога се налага да създадем собствени атрибути за валидация.

**Пример за персонализирана валидация:**

```csharp
public class IsBefore : ValidationAttribute
{
    private const string DateTimeFormat = "dd/MM/yyyy";
    private readonly DateTime date;

    public IsBefore(string dateInput)
    {
        date = DateTime.ParseExact(dateInput, DateTimeFormat, CultureInfo.InvariantCulture);
        ErrorMessage = "The date must be before " + date.ToString(DateTimeFormat); // Custom error message
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value >= date)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
```

След това може да се използва в модела:

```csharp
public class RegisterUserModel 
{
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(20)]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [IsBefore("01/01/2000")]
    public DateTime BirthDate { get; set; }
}
```

**Какво се случва зад кулисите:**

Когато ASP.NET извършва **валидация на модел**, той използва **reflection**, за да обиколи всички свойства на модела и провери дали върху тях има атрибути, наследени от `ValidationAttribute`.

За всеки такъв атрибут:

- ASP.NET **извиква метода `IsValid()`**, като му подава стойността на съответното property и `ValidationContext`.

- Ако `IsValid()` върне `ValidationResult.Success`, значи стойността е валидна.

- Ако върне `ValidationResult` с грешка, тя се добавя в `ModelState`.

Това важи както за вградените атрибути (`[Required]`, `[Range]`, `[StringLength]`), така и за всички **потребителски (custom)**, които си създадем сами.

**Важно:** методът `IsValid()` се изпълнява **автоматично** – не се налага ръчно да го извикваме никъде. Единственото изискване е атрибутът да бъде поставен върху свойство или параметър.
#### `IValidatableObject`
Можем също така да добавим валидация директно в binding модела, като използваме интерфейса `IValidatableObject`. Това е подходящо в случаите, когато валидацията е по-сложна и стандартните атрибути не са достатъчни. В такъв случай моделът трябва да имплементира интерфейса `IValidatableObject`, за да може да съдържа собствена логика за проверка на валидността.

```csharp
public class RegisterUserModel : IValidatableObject
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Username)) 
            yield return new ValidationResult("Username cannot be empty");

        if (string.IsNullOrEmpty(Password)) 
            yield return new ValidationResult("Password cannot be empty");

        if (ConfirmPassword != Password) 
            yield return new ValidationResult("Passwords do not match");
    }
}
```
## Uploading and Downloading Files
### Uploading Files
ASP.NET Core MVC позволява лесно качване на файлове чрез стандартен model binding. При работа с по-големи файлове се използва стрийминг за по-ефективна обработка. 

```csharp
<form method="post" enctype="multipart/form-data"
      asp-controller="Files" asp-action="Upload">
    <input type="file" name="file">
    <button type="submit" value="Upload" />
</form>
```

Системата поддържа и качване на няколко файла едновременно.

```csharp
<form method="post" enctype="multipart/form-data"
      asp-controller="Files" asp-action="Upload">
    <input type="file" name="files" multiple>
    <button type="submit" value="Upload" />
</form>
```

Когато качваме файлове чрез model binding, екшън методът трябва да приема.

`IFormFile` (за единичен файл) или `IEnumerable<IFormFile>` (или `List<IFormFile>`) за множество файлове.

Качване на файлове:

```csharp
[HttpPost("Upload")]
public async Task<IActionResult> Upload(List<IFormFile> files)
{
    var filePath = Path.GetTempFileName(); // Full path to file in temp location

    foreach (var formFile in files.Where(f => f.Length > 0))
    {
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }
    } // Copy files to FileSystem using Streams

    var bytes = files.Sum(f => f.Length);
    return Ok(new { count = files.Count, bytes, filePath });
}
```
### Downloading Files
ASP.NET Core абстрахира достъпа до файловата система чрез File Providers.

File Providers се използват в цялата ASP.NET Core платформа.

Примери за вътрешна употреба на File Providers в ASP.NET Core:

`IHostingEnvironment` предоставя достъп до content root и web root на приложението.

Static File Middleware използва File Providers, за да намира статични файлове.

Razor използва File Providers, за да намира страници и изгледи.

Качване на файлове:

За достъп до физически файлове трябва да използваме `PhysicalFileProvider`.

Необходимо е да я инициализираме с пътя към физическата папка на сървъра.

След това можем да извлечем информация за самия файл.

```csharp
public IActionResult Download(string fileName)
{
    // Construct the path to the physical files folder
    string filePath = this.env.ContentRootPath + this.config["FileSystem:FilesFolderPath"];

    IFileProvider provider = new PhysicalFileProvider(filePath); // Initialize the Provider
    IFileInfo fileInfo = provider.GetFileInfo(fileName); // Extract the FileInfo
    var readStream = fileInfo.CreateReadStream(); // Extract the Stream
    var mimeType = "application/octet-stream"; // Set a mimeType

    return File(readStream, mimeType, fileName); // Return FileResult
} 
// NOTE: There is no check if the File exists. This action may result in an error
```
## Razor
### Syntax
Прост синтаксис на view engine.

Code-focused templating подход.

Лесен преход между HTML и код.

Комбиниране на HTML и C#.

```html
<div class="article">
    <div>@article.Title</div>
    <div>@article.Content</div>
</div>

<ul id="products">
    @foreach (var p in products)
    {
        <li>@p.Name ($@p.Price)</li>
    }
</ul>
```

`@` - За стойности (HTML encoded)

```html
<p>
 Current time is: @DateTime.Now  
 Not HTML encoded value: @Html.Raw(someVar)
</p>
```

`@{…}` - За кодови блокове (за да запазим изгледа опростен)

```html
@{
 var productName = "Energy drink";
 if (Model != null) { productName = Model.ProductName; }
 else if (ViewBag.ProductName != null) { productName = ViewBag.ProductName; }
}

<p>Product "@productName" has been added in your shopping cart</p>
```

If, else, for, foreach и други C# конструкции.  

HTML markup може да се включва навсякъде в кода.  

`@:` - За изрично изписване на обикновен текст на отделен ред.

```html
<div class="products-list">
    @if (Model.Products.Count() == 0) 
    { 
        <p>Sorry, no products found!</p> 
    }
    else
    {
        @:List of the products found:
        foreach(var product in Model.Products)
        {
            <b>@product.Name, </b>
        }
    }
</div>
```

Comments:

```html
@* A Razor Comment *@

@{
    // A C# comment

    /* A Multi
       line C# comment */
}

<!-- HTML Comment -->
```

Escaping `@`:

```html
<p>
    This is the sign that separates email names from domains: @@<br />
    And this is how smart Razor is: spam_me@gmail.com
</p>
```

 `@(...)` - явен (explicit) израз:

```html
<p>
    Current rating (0-10): @Model.Rating / 10.0      @* 6 / 10.0 *@
    Current rating (0-1): @(Model.Rating / 10.0)     @* 0.6 *@
    spam_me@Model.Rating                             @* spam_me@Model.Rating *@
    spam_me@(Model.Rating)                           @* spam_me6 *@
</p>
```

`@using` - за включване на namespace в view-то.
`@model` - за дефиниране на модела за изгледа.

```html
@using MyWebApp.Models; 
@model UserModel

<p>@Model.Username</p>
```
### Views – Dependency Injection
ASP.NET Core поддържа Dependency Injection директно във View-ове.

Можем да инжектираме услуга във View, като използваме директивата `@inject`.

Пример:

```html
@inject IDateTimeService DateService

<p>Current server time: @DateService.Now</p>
```

Това позволява на View-овете да имат достъп до логика от регистрирани в контейнера за зависимости услуги, без да е необходимо тя да бъде подавана чрез модела или `ViewBag`.

```csharp
// DataService.cs
public class DataService
{
    public IEnumerable<string> GetData()
    {
        return new[] { "David", "John", "Max", "George" };
    }
}

// In Program.cs
builder.Services.AddScoped<DataService, DataService>();

// In Razor view
@using Demo.Services
@inject DataService DataService

<div class="list">
    @foreach (var item in DataService.GetData())
    {
        <h1>@item</h1>
    }
</div>
```
## Layout and Special View Files
Когато ASP.NET Core MVC рендерира изглед (view), той първо търси `.cshtml` файла в папка с името на контролера – например, ако контролерът се казва `HomeController`, ще се потърси изгледът в `Views/Home/`. Там ще се търси файл, съответстващ на името на действието (action).

Ако изглед с такова име не бъде открит в тази папка, тогава се извършва второ търсене – в папката `Views/Shared/`, където се намират общи изгледи, използвани от няколко контролера.

View файловете, които искаме да бъдат достъпни от всеки контролер, трябва да бъдат разположени в папката `Shared`. Тази папка се намира в `Views/Shared` и служи за съхранение на общи изгледи като `_Layout.cshtml`, грешки или други компоненти, използвани многократно.

Ако `HomeController` има `Test` action, при извикване на `return View();` в този action, **ASP.NET Core MVC първо ще потърси View с име `Test` в папката `Views/Home/`**, понеже така се казва контролерът.

Ако **не открие `Test.cshtml` там**, тогава **ще продължи да търси `Test.cshtml` в `Views/Shared/`**.

Ако има `Views/Shared/Test.cshtml`, и **няма файл с такова име в `Views/Home/`**, тогава **Shared версията ще бъде заредена автоматично**.

Но ако и двете съществуват – `Views/Home/Test.cshtml` и `Views/Shared/Test.cshtml` – **предимство има това в `Views/Home/`**, защото се счита за по-специфично.
### `_Layout.cshtml`
Определя се общ шаблон за сайта чрез файла `~/Views/Shared/_Layout.cshtml`. Това е контейнерът, в който се визуализира съдържанието на отделните страници в браузъра.

Layout-ът има две основни части: самият общ шаблон (layout) и мястото, където се вмъква съдържанието на конкретното view – чрез `@RenderBody()`.

При нужда можем да посочим различен layout за конкретно view, като зададем `Layout = "_OtherLayout"` в самото view или в базов view файл.

Razor View engine рендерира съдържанието от вътре навън. Първо се рендерира самият View, а след това Layout-а.

`@RenderBody()` показва къде искаме изгледите, базирани на този Layout, да "попълнят" основното си съдържание в тази част от HTML-а.
### Sections
В Razor можем да имаме една или повече „секции“ (по избор), които се дефинират в самите изгледи (views). Те могат да бъдат визуализирани на произволно място в layout страницата чрез метода `RenderSection()`.

View-то се визуализира на мястото, където в layout файла е поставен `@RenderBody()`, но не цялото съдържание задължително попада там. Във View-то можем да дефинираме отделни блокове, наречени _секции_, които да бъдат изобразени на конкретни места в layout-а чрез `@RenderSection()`. Например често използвана практика е да създадем секция `scripts`, в която слагаме JavaScript код. Тази секция след това се визуализира в края на layout файла – обикновено преди затварящия `</body>` таг:

```csharp
@RenderSection("scripts", required: false)
```

А във view-то:

```html
@section scripts {
    <script>
        console.log("Hello from the view!");
    </script>
}
```

Така имаме контрол не само върху основното съдържание, но и върху допълнителни блокове, като скриптове, стилове или мета тагове.

Използва се синтаксисът `@RenderSection(string name, bool required)`. Ако зададената секция е задължителна (`required = true`), но не е дефинирана в конкретното view, ще бъде хвърлено изключение. Можем да проверим дали секцията е дефинирана чрез `IsSectionDefined()`.
### `_ViewStart.cshtml`
View-тата не е нужно да задават layout ръчно, тъй като по подразбиране използват layout файла, зададен в **`_ViewStart.cshtml`**.  
Този файл се намира в `~/Views/_ViewStart.cshtml` и съдържа код, който автоматично се изпълнява в началото на всяко view.
Обикновено в него се задава layout, но можем да добавим и други общи настройки или код, които искаме да се прилагат към всички наши view-та.

Все пак, всяко view може да зададе **собствен layout**, ако е необходимо:

```
@{
	 Layout = "~/Views/Shared/_UncommonLayout.cshtml";
}
```

Ако искаме дадено view да **няма layout изобщо**, това се прави така:

```
@{
	 Layout = null;
}
```
### `_ViewImports.cshtml`
Ако дадена директива или зависимост се използва в много View-та, тя може да бъде зададена глобално във файла **`_ViewImports.cshtml`**.  
Този файл се намира в `~/Views/_ViewImports.cshtml` и съдържа общи Razor директиви, които се прилагат към всички view-та.

```
@using MyWebApp
@using MyWebApp.Models
@using MyWebApp.Models.AccountViewModels
@using MyWebApp.Models.ManageViewModels
@using Microsoft.AspNetCore.Identity
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

>[!NOTE]
>Този файл **не поддържа други Razor функционалности** (като логика или съдържание), а само директиви като `@using`, `@model`, `@addTagHelper` и други подобни.
### `_ValidationScriptsPartial.cshtml`
Файлът **`_ValidationScriptsPartial.cshtml`** съдържа скриптове за валидация под формата на **partial view**. Обикновено се намира в `~/Views/Shared/`.

Той включва два основни скрипта:

```
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
```

За да се използват тези скриптове във View-то, се рендерира partial view-то вътре в секция, обикновено `Scripts`:

```
@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

>[!NOTE]
>Секцията `Scripts` трябва да съществува в layout файла чрез `@RenderSection("Scripts", required: false)`, за да може скриптовете да се вмъкнат на правилното място в HTML-а.
## Partial Views and View Components
Partial Views се използват за рендиране на **части от страница**. Те помагат да:

- **Разделим големи HTML файлове** на по-малки, по-лесни за поддръжка компоненти
- **Намалим дублирането** на повтарящ се Razor код (например таблици, форми, списъци и др.)
- Се **повторно използват** в различни View-та

Технически това са обикновени `.cshtml` файлове и обикновено се намират в папка `/Shared/` или в същата папка, в която ги използваме.  
Извикват се с `@Html.Partial()`, `@await Html.PartialAsync()` или с `<partial name="..." />` (Tag Helper).

Идеята на partial view-тата е да **разделим голямото view на по-малки, самостоятелни компоненти** – мини Razor изгледи, които “редим” един след друг, за да получим цялата страница.
### Use of Partial Views
**HTML Helper for Partial Views:**

```
@using WebApplication.Models;
@model ProductsListViewModel
@foreach (var product in Model.Products)
{
    @await Html.PartialAsync("_ProductPartial", product);
}
```

**Tag Helper for Partial Views:**

```
@foreach (var product in Model.Products)
{
    <partial name="_ProductPartial" model="product" />
}
```

Ако **частичното view няма нужда от модел**, просто го извикваме така:

```html
<partial name="_SomePartial" />
```

Ако **искаме да му подадем конкретен модел:**

```html
<partial name="_SomePartial" model="someObject" />
```

И вътре в `_SomePartial.cshtml` трябва да посочим подходящия тип:

```html
@model SomeType
```
## View Components
**View Components** са подобни на Partial Views, но предлагат **много по-голяма функционалност**.

**Не използват model binding автоматично**, а разчитат на **експлицитно подадени данни**.

**Рендират част от страницата**, а не цял отговор (response), подобно на partial views.

**Поддържат параметри** и позволяват вградена **бизнес логика**.

Обикновено се извикват от **Layout** или друго view.

Запазват принципите на **разделяне на отговорности** и **testability**, подобно на Controller + View архитектурата.

View компонентите са предназначени за случаи, в които имаме **преизползваема логика за визуализация**, която е **твърде сложна за partial view**. Те позволяват вграждане на логика, извличане на данни и независима визуализация.

Подходящи примери за View компоненти са:

- **Динамични навигационни менюта**

- **Панели за вход (login panels)**

- **Количка за пазаруване**

- **Съдържание в странична лента (sidebar)**

- **Последно публикувани статии**

- **Tag cloud**

Това са елементи, които може да се появяват на различни места в сайта, използват данни и имат логика, но не е практично да ги изграждаме с обикновен partial view.

С други думи:  
**Partial View** = "глупав" шаблон без логика.
**View Component** = "умен" шаблон с логика и входни параметри.

Примерно можем да направим компонент `<vc:cart-summary />`, който изчислява и визуализира текущата количка – логиката е вътре, а не в контролера.

View компонентите се състоят от **две части**:

- **Клас** - който наследява `ViewComponent`.

- **View** - задължително трябва да има поне едно view, като по конвенция това е `Default.cshtml`. Може да създадем и други изгледи за различни случаи, но `Default.cshtml` е задължителен, тъй като се използва по подразбиране, когато в `ViewComponent` класа върнем `return View();` без да укажем име на изглед.

Характеристики на View компонентите:

- Цялата логика се дефинира в метод с име `InvokeAsync()`.

- Те **никога не обработват директно HTTP заявки** (за разлика от контролери).

- Обикновено подготвят **модел**, който се подава към съответното View.

Така можем да капсулираме логиката и визуализацията на малка, многократно използвана част от страницата.
### Defining Our Own `ViewComponent`
1. **Създаване на `ViewComponent`**

```csharp
public class HelloWorldViewComponent : ViewComponent
{
    private readonly DataService _dataService;

    public HelloWorldViewComponent(DataService dataService)
        => _dataService = dataService;

    public async Task<IViewComponentResult> InvokeAsync(string name)
    {
        string helloMessage = await _dataService.GetHelloAsync();
        ViewData["Message"] = helloMessage;
        ViewData["Name"] = name;
        return View(); // it will load Views/Shared/Components/HelloWorld/Default.cshtml
    }
}
```

- Наследява `ViewComponent`.

- Има метод `InvokeAsync`, който съдържа логиката.

- Не обработва директно HTTP заявки.

- Често подготвя модел или ползва `ViewData`.

2. **View-то за компонента**

**Path**: `Views/Shared/Components/HelloWorld/Default.cshtml`

```html
<h1>@ViewData["Message"]!!! I am @ViewData["Name"]</h1>
```

3. **Извикване на компонента в изглед**

**Path**: `Views/Home/Index.cshtml`

```html
<div class="view-component-content">
    @await Component.InvokeAsync("HelloWorld", new { name = "David" })
    <vc:HelloWorld name="John"></vc:HelloWorld>
</div>
```

- `Component.InvokeAsync()` е стандартният начин за асинхронно извикване

- `<vc:HelloWorld>` е Tag Helper, който трябва да се регистрира

4. **Регистриране на Tag Helper**

Ако искаме да използваме `<vc:...>` синтаксиса:

```
@addTagHelper *, YourAppName
```

**Обобщение:**

`ViewComponents` са мощен инструмент за капсулиране на логика и визуализация в многократно използваеми блокове, особено подходящи за по-сложни UI части като менюта, панели и др.
## HTML Helpers and Tag Helpers
### HTML Helpers
Всяко view наследява от `RazorPage`.

`RazorPage` има свойство на име `Html`, което предоставя различни методи връщащи низове. Тези методи могат да се използват за създаване на HTML елементи като:

- input полета

- линкове
    
- форми
    

Въпреки това, днес се препоръчва да се избягва използването на HTML Helpers и вместо това да се използват Tag Helpers, които са по-модерни и удобни за работа.

Примери за HTML Helpers:

| `HTML Helper`        | Description               |
| -------------------- | ------------------------- |
| `@Html.ActionLink`   | Създава линк към действие |
| `@Html.TextBox`      | Създава текстово поле     |
| `@Html.BeginForm`    | Започва форма             |
| `@Html.TextArea`     | Създава текстова област   |
| `@Html.CheckBox`     | Създава чекбокс           |
| `@Html.Password`     | Създава поле за парола    |
| `@Html.Display`      | Показва стойност          |
| `@Html.Hidden`       | Създава скрито поле       |
| `@Html.Editor`       | Създава подходящ редактор |
| `@Html.Label`        | Създава етикет            |
| `@Html.DropDownList` | Създава падащ списък      |
| `@Html.Action`       | Рендерира действие        |
### Tag Helper

# Misc
# ChatGPT
# Bookmarks
[C# Web Basics - Workshop - Web Application. Advanced CSS - Bootstrap - май 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=iG2UBr2fAqg)

[Polyglot Persistence - YouTube](https://www.youtube.com/watch?v=T9h9SlVn8rw)

Completion: 16.05.2025